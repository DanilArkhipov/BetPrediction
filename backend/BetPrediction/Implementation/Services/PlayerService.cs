using System.Globalization;
using AutoMapper;
using CsvHelper;
using Implementation.Extensions;
using Implementation.OpenDotaApi.Models.Responses;
using Models.Entities.Player;
using Parsers;
using Parsers.Models.Player;
using Repositories;
using Repositories.Models.Entities;
using Repositories.Models.Enums;
using Services;

namespace Implementation.Services;

public class PlayerService : IPlayerService
{
    private readonly IMapper _mapper;
    private readonly HttpClient _openDotaHttpClient;
    private readonly IPlayerGameRepository _playerGameRepository;
    private readonly IParser<PlayerFullInfo, BaseParserParams> _playerInfoParser;
    private readonly IPlayerRepository _playerRepository;
    private readonly IPaginatedParser<PlayerShortInfo, BaseTableParserParams> _playerShortInfoParser;

    public PlayerService(IPlayerRepository playerRepository, IHttpClientFactory httpClientFactory,
        IMapper mapper, IPaginatedParser<PlayerShortInfo, BaseTableParserParams> playerShortInfoParser,
        IParser<PlayerFullInfo, BaseParserParams> playerInfoParser, IPlayerGameRepository playerGameRepository)
    {
        _playerRepository = playerRepository;
        _openDotaHttpClient = httpClientFactory.CreateClient(Constants.OpenDotaApiHttpClientName);
        _mapper = mapper;
        _playerShortInfoParser = playerShortInfoParser;
        _playerInfoParser = playerInfoParser;
        _playerGameRepository = playerGameRepository;
    }

    public async Task LoadPlayersDataToSystem()
    {
        var parsedPlayersList = new List<PlayerFullInfo>();
        await foreach (var playerShortInfoList in _playerShortInfoParser.Parse())
        foreach (var playerShortInfo in playerShortInfoList.ParsedDataList)
        {
            var fullInfo =
                await _playerInfoParser.Parse(new BaseParserParams { ParsingUrl = playerShortInfo.PlayerUrl });
            if (fullInfo == null) continue;
            fullInfo.PlayerUrl = playerShortInfo.PlayerUrl;
            fullInfo.Name = playerShortInfo.Name;
            fullInfo.MatchesCount = playerShortInfo.MatchesCount;
            fullInfo.Region = playerShortInfo.Region;
            fullInfo.Team = playerShortInfo.Team;
            fullInfo.TotalPrize = playerShortInfo.TotalPrize;
            parsedPlayersList.Add(fullInfo);
        }

        var proPlayersList = await _openDotaHttpClient.GetDataAsync<List<ProPlayerData>>("proPlayers");
        var updatedPlayers = new List<PlayerEntity>(proPlayersList.Count);
        var playerSteamProfileDict = new Dictionary<string, PlayerFullInfo>();
        foreach (var player in parsedPlayersList)
        {
            if (playerSteamProfileDict.ContainsKey(player.SteamProfileUrl))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(player.PlayerUrl);
                Console.ForegroundColor = ConsoleColor.White;
                continue;
            }

            playerSteamProfileDict.Add(player.SteamProfileUrl, player);
        }


        foreach (var player in proPlayersList)
            try
            {
                if (!playerSteamProfileDict.ContainsKey(player.ProfileUrl)) continue;
                var playerEntity = await _playerRepository.GetPlayerByAccountId(player.AccountId);


                if (playerEntity is not null)
                    _mapper.Map(player, playerEntity);
                else
                    playerEntity = _mapper.Map<PlayerEntity>(player);

                playerEntity.PlayerRole = GetPlayerRole(playerSteamProfileDict[player.ProfileUrl].Role);
                playerEntity.BirthDate = GetPlayerBirthDate(playerSteamProfileDict[player.ProfileUrl].BirthDate);
                playerEntity.TotalPrizesInDollars =
                    GetTotalPrizes(playerSteamProfileDict[player.ProfileUrl].TotalPrize);
                playerEntity.MatchesCount = Convert.ToInt32(playerSteamProfileDict[player.ProfileUrl].MatchesCount);
                playerEntity.ProfessionalAvatarUrl = playerSteamProfileDict[player.ProfileUrl].PlayerProfessionalAvatar;
                updatedPlayers.Add(playerEntity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        await _playerRepository.SavePlayersAsync(updatedPlayers);
    }

    public Task<string> GeneratePlayerDataSetForPeriod(DateOnly startDate, DateOnly endDate)
    {
        throw new NotImplementedException();
    }

    public async Task<string> GeneratePlayerIndicatorsDatasetForPeriod(DateOnly startDate, DateOnly endDate)
    {
        var players = await _playerRepository.GetPlayersAsync();
        var playerGames = await _playerGameRepository.GetPlayerGamesAsync();
        var playersDict = players.ToDictionary(x => x.AccountId);
        var playerIndicators = playerGames
            .Select(x =>
            {
                var playerIndicators = _mapper.Map<PlayerIndicators>(x);
                if (playerIndicators.AccountId.HasValue && playersDict.ContainsKey(playerIndicators.AccountId.Value))
                    playerIndicators.PlayerRole = playersDict[playerIndicators.AccountId.Value].PlayerRole switch
                    {
                        PlayerRole.Core => 0,
                        PlayerRole.Support => 1
                    };

                return playerIndicators;
            })
            .ToList();
        // foreach (var group in gamesByPlayers)
        // {
        //     var 
        // }
        return await GenerateDataSetForPlayerIndicators(playerIndicators);
    }

    public async Task<string> GeneratePlayerAvgIndicatorsDatasetForPeriod(DateOnly startDate, DateOnly endDate)
    {
        var playerGames = await _playerGameRepository.GetPlayerGamesAsync();
        var gamesGroupedByPlayers = playerGames.GroupBy(x => x.AccountId);
        var playerIndicators = new List<AveragePlayerIndicators>(gamesGroupedByPlayers.Count());
        foreach (var group in gamesGroupedByPlayers)
        {
            var indicators = new AveragePlayerIndicators();
            indicators.AccountId = group.Key;
            foreach (var game in group)
            {
                indicators.AssistsCount += game.AssistsCount ?? 0;
                indicators.Deaths += game.Deaths ?? 0;
                indicators.Gold += game.Gold ?? 0;
                indicators.KillsCount += game.KillsCount ?? 0;
                indicators.TowerDamage += game.TowerDamage ?? 0;
                indicators.XpPerMin += game.XpPerMin ?? 0;
                indicators.TotalGold += game.TotalGold ?? 0;
                indicators.TotalXp += game.TotalXp ?? 0;
                indicators.Kda += game.Kda ?? 0;
            }

            indicators.AssistsCount /= group.Count();
            indicators.Deaths /= group.Count();
            indicators.Gold /= group.Count();
            indicators.KillsCount /= group.Count();
            indicators.TowerDamage /= group.Count();
            indicators.XpPerMin /= group.Count();
            indicators.TotalGold /= group.Count();
            indicators.TotalXp /= group.Count();
            indicators.Kda /= group.Count();
            playerIndicators.Add(indicators);
        }

        return await GenerateDataSetForAvgPlayerIndicators(playerIndicators);
    }

    private PlayerRole GetPlayerRole(string playerRoleString)
    {
        return playerRoleString switch
        {
            "Керри" => PlayerRole.Core,
            "Мидер" => PlayerRole.Core,
            "Оффлейнер" => PlayerRole.Core,
            _ => PlayerRole.Support
        };
    }

    private DateTime GetPlayerBirthDate(string playerBirthDateString)
    {
        DateTime playerBirthDateParsed;
        DateTime.TryParseExact(playerBirthDateString, "dd.MM.yyyy", CultureInfo.GetCultureInfo("ru-RU"),
            DateTimeStyles.None, out playerBirthDateParsed);
        return playerBirthDateParsed;
    }

    private double GetTotalPrizes(string totalPrizesString)
    {
        return Convert.ToDouble(totalPrizesString.Replace("$", "").Replace(" ", ""));
    }

    private async Task<string> GenerateDataSetForPlayerIndicators(List<PlayerIndicators> indicatorsList)
    {
        using (var writer = new StreamWriter("PlayerIndicators.csv"))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteHeader<PlayerIndicators>();
            await csv.NextRecordAsync();

            foreach (var row in indicatorsList)
            {
                csv.WriteRecord(row);
                await csv.NextRecordAsync();
            }
        }

        return "";
    }

    private async Task<string> GenerateDataSetForAvgPlayerIndicators(List<AveragePlayerIndicators> indicatorsList)
    {
        using (var writer = new StreamWriter("AveragePlayerIndicators.csv"))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteHeader<AveragePlayerIndicators>();
            await csv.NextRecordAsync();

            foreach (var row in indicatorsList)
            {
                csv.WriteRecord(row);
                await csv.NextRecordAsync();
            }
        }

        return "";
    }
}