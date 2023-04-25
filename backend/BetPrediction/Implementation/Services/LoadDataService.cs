using AutoMapper;
using Implementation.Extensions;
using Implementation.OpenDotaApi.Models.Responses;
using Parsers;
using Parsers.Models.Player;
using Repositories;
using Repositories.Models.Entities;
using Services;

namespace Implementation.Services;

public class LoadDataService : ILoadDataService
{
    private readonly IPlayerRepository _playerRepository;
   // private readonly IPaginatedParser<PlayerShortInfo, BaseTableParserParams> _playerShortInfoParser;
    private readonly HttpClient _openDotaHttpClient;
    private readonly IMapper _mapper;

    public LoadDataService(IPlayerRepository playerRepository,
        IHttpClientFactory httpClientFactory, IMapper mapper)
    {
        _playerRepository = playerRepository;
       // _playerShortInfoParser = playerShortInfoParser;
        _mapper = mapper;
        _openDotaHttpClient = httpClientFactory.CreateClient(Constants.OpenDotaApiHttpClientName);
    }

    public async Task LoadDataToSystem()
    {
        // var updateRequestStartTime = DateTime.Now;
        // var allTeamsList = await GetAllOpenDotaTeamsList();
        // await LoadPlayersData(updateRequestStartTime, allTeamsList);
        // int number = 0;
        // await foreach (var playersPageData in _playerShortInfoParser.Parse())
        // {
        //     foreach (var playerShortInfo in playersPageData.ParsedDataList)
        //     {
        //         //var player = await _playerRepository.GetPlayerByNameAsync(playerShortInfo.Name) ?? new Player();
        //         Console.WriteLine($"{++number}: {playerShortInfo.Name}");
        //     }
        // }
        //
        // var players = await _playerRepository.GetPlayersAsync();
        //
        // if (players.Any())
        // {
        //     Console.WriteLine("Данные есть!");
        // }
        //
        // else
        // {
        //     Console.WriteLine("Данных нет!");
        // }
    }

    private async Task SetTeamDataToPlayer(PlayerEntity playerEntity, List<TeamData> openDotaTeams, DateTime updateRequestStartTime)
    {
        if (playerEntity.TeamId is null)
        {
            return;
        }

        try
        {
            var teamEntity = playerEntity.Team ?? new TeamEntity();
            if (teamEntity.LastUpdateTime != updateRequestStartTime)
            {
                // Возможно стоит искать еще по TeamName
                var teamData = openDotaTeams.First(data =>
                    data.TeamId == playerEntity.TeamId);
                _mapper.Map(teamData, teamEntity);
                teamEntity.LastUpdateTime = updateRequestStartTime;
                teamEntity.TeamMembers = new List<PlayerEntity>();
            }
            
            playerEntity.Team = teamEntity;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
        
    }
}