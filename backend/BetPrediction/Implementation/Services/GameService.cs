using System.Globalization;
using AutoMapper;
using CsvHelper;
using Implementation.Extensions;
using Implementation.OpenDotaApi.Models.Responses;
using Implementation.Parsers.Models.Match;
using Models.Entities.Game;
using Parsers;
using Repositories;
using Repositories.Models.Entities;
using Services;

namespace Implementation.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;
    private readonly ILeagueRepository _leagueRepository;
    private readonly IMapper _mapper;
    private readonly IPaginatedParser<MatchesListItem, BaseTableParserParams> _matchesListParser;
    private readonly IParser<MatchInfo, BaseParserParams> _matchParser;
    private readonly HttpClient _openDotaHttpClient;
    private readonly IPickBanRepository _pickBanRepository;
    private readonly IPlayerGameRepository _playerGameRepository;
    private readonly IPlayerRepository _playerRepository;

    public GameService(IPaginatedParser<MatchesListItem, BaseTableParserParams> matchesListParser,
        IParser<MatchInfo, BaseParserParams> matchParser, IHttpClientFactory httpClientFactory,
        IPlayerGameRepository playerGameRepository, IPickBanRepository pickBanRepository, IMapper mapper,
        ILeagueRepository leagueRepository, IGameRepository gameRepository, IPlayerRepository playerRepository)
    {
        _matchesListParser = matchesListParser;
        _matchParser = matchParser;
        _playerGameRepository = playerGameRepository;
        _pickBanRepository = pickBanRepository;
        _mapper = mapper;
        _leagueRepository = leagueRepository;
        _gameRepository = gameRepository;
        _playerRepository = playerRepository;
        _openDotaHttpClient = httpClientFactory.CreateClient(Constants.OpenDotaApiHttpClientName);
    }

    /// <summary>
    ///     Загрузить игры в систему
    /// </summary>
    /// <param name="startDate">Дата с которой нужно загружать игры</param>
    public async Task LoadGamesToSystem(DateOnly startDate)
    {
        await foreach (var matchesList in _matchesListParser.Parse())
        {
            var countOfMatchesAfterStartDateOnPage = 0;
            foreach (var match in matchesList.ParsedDataList)
            {
                if (startDate > match.Date) continue;

                countOfMatchesAfterStartDateOnPage++;
                var matchData = await _matchParser.Parse(new BaseParserParams { ParsingUrl = match.MatchUrl });
                foreach (var gameId in matchData.GameIdList)
                    try
                    {
                        var gameData = await _openDotaHttpClient.GetDataAsync<GameData>($"matches/{gameId}");

                        await SavePlayerGames(gameData);
                        await SavePickBans(gameData);
                        await SaveLeague(gameData);

                        var gameEntity = await _gameRepository.GetGameByIdAsync(gameData.MatchId);
                        if (gameEntity == null)
                        {
                            gameEntity = _mapper.Map<GameEntity>(gameData);
                            await _gameRepository.SaveGameAsync(gameEntity);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
            }

            if (countOfMatchesAfterStartDateOnPage == 0) return;
        }
    }

    public async Task<string> GenerateGamesDataSetForPeriod(DateOnly startDate, DateOnly endDate)
    {
        var playerGames = await _playerGameRepository.GetPlayerGamesAsync();
        var games = playerGames
            .Where(x=>x.GameId.HasValue)
            .GroupBy(x => x.GameId);
        var datasetRows = new List<GamesDataSetRow>();
        foreach (var game in games)
        {
            var row = new GamesDataSetRow();
            var radiantPlayers = game
                .Where(x=>x.IsRadiant.HasValue && x.IsRadiant.Value)
                .ToList();
            var direPlayers = game
                .Where(x => x.IsRadiant.HasValue && !x.IsRadiant.Value)
                .ToList();

            if (radiantPlayers.Count != 5 || direPlayers.Count != 5) continue;

            row.RadiantPlayer1Id = radiantPlayers[0].AccountId.Value;
            row.RadiantPlayer2Id = radiantPlayers[1].AccountId.Value;
            row.RadiantPlayer3Id = radiantPlayers[2].AccountId.Value;
            row.RadiantPlayer4Id = radiantPlayers[3].AccountId.Value;
            row.RadiantPlayer5Id = radiantPlayers[4].AccountId.Value;

            row.DirePlayer1Id = direPlayers[0].AccountId.Value;
            row.DirePlayer2Id = direPlayers[1].AccountId.Value;
            row.DirePlayer3Id = direPlayers[2].AccountId.Value;
            row.DirePlayer4Id = direPlayers[3].AccountId.Value;
            row.DirePlayer5Id = direPlayers[4].AccountId.Value;

            row.RadiantWin = radiantPlayers[0].Win.Value;

            datasetRows.Add(row);
        }

        using (var writer = new StreamWriter("GamesDataSet.csv"))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteHeader<GamesDataSetRow>();
            await csv.NextRecordAsync();

            foreach (var datasetRow in datasetRows)
            {
                csv.WriteRecord(datasetRow);
                await csv.NextRecordAsync();
            }
        }

        return "";
    }

    private async Task SavePlayerGames(GameData gameData)
    {
        if (gameData.Players == null) return;

        var playerGameEntityList = await _playerGameRepository.GetPlayerGamesByGameId(gameData.MatchId);
        var playerAccountIdList = playerGameEntityList.Select(x => x.AccountId);
        var newPlayerGameEntities = new List<PlayerGameEntity>(10);
        newPlayerGameEntities.AddRange(from playerGame in gameData.Players
            where !(playerAccountIdList?.Contains(playerGame.AccountId) ?? false)
            select _mapper.Map<PlayerGameEntity>(playerGame));

        await _playerGameRepository.SavePlayerGamesAsync(newPlayerGameEntities);
    }

    private async Task SavePickBans(GameData gameData)
    {
        if (gameData.PicksBans == null || gameData.RadiantWin == null) return;

        var pickBanEntityList = await _pickBanRepository.GetPickBansByGameId(gameData.MatchId);
        var heroIdList = pickBanEntityList.Select(x => x.OpenDotaHeroId);
        var newPickBanEntities = new List<PickBanEntity>(24);
        newPickBanEntities.AddRange(from pickBan in gameData.PicksBans
            where !(heroIdList?.Contains(pickBan.OpenDotaHeroId) ?? false)
            select _mapper.Map(pickBan,
                new PickBanEntity { Win = (pickBan.Team == 0 ? gameData.RadiantWin : !gameData.RadiantWin).Value }));

        await _pickBanRepository.SavePickBansAsync(newPickBanEntities);
    }

    private async Task SaveLeague(GameData gameData)
    {
        if (gameData.League == null) return;

        var leagueEntity = await _leagueRepository.GetLeagueByLeagueId(gameData.League.LeagueId);

        if (leagueEntity != null) return;

        leagueEntity = _mapper.Map<LeagueEntity>(gameData.League);
        await _leagueRepository.SaveLeague(leagueEntity);
    }
}