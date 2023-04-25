using AutoMapper;
using Implementation.Extensions;
using Implementation.OpenDotaApi.Models.Responses;
using Parsers;
using Parsers.Models.Player;
using Repositories;
using Repositories.Models.Entities;
using Services;

namespace Implementation.Services;

public class TeamService: ITeamService
{
    private readonly IPlayerRepository _playerRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly HttpClient _openDotaHttpClient;
    private readonly IMapper _mapper;

    public TeamService(IPlayerRepository playerRepository, IHttpClientFactory httpClientFactory, IMapper mapper, ITeamRepository teamRepository)
    {
        _playerRepository = playerRepository;
        _openDotaHttpClient = httpClientFactory.CreateClient(Constants.OpenDotaApiHttpClientName);
        _mapper = mapper;
        _teamRepository = teamRepository;
    }

    public async Task LoadTeamsDataToSystem()
    {
        var openDotaTeams = await GetOpenDotaTeamsAsync();
        var updatedTeams = new List<TeamEntity>(openDotaTeams.Count);

        foreach (var team in openDotaTeams)
        {
            var teamEntity = await _teamRepository.GetTeamByOpenDotaId(team.TeamId);
            var players = await _playerRepository.GetTeamPlayersList(team.TeamId);

            if (teamEntity is null)
            {
                teamEntity = _mapper.Map<TeamEntity>(team);
            }
            else
            {
                _mapper.Map(team, teamEntity);
            }

            teamEntity.TeamMembers = players;
            updatedTeams.Add(teamEntity);
        }

        await _teamRepository.SaveTeamsAsync(updatedTeams);
    }

    // public async Task LoadTeamsDataToSystem()
    // {
    //     var openDotaTeams = await GetOpenDotaTeamsAsync();
    //
    //     foreach (var team in openDotaTeams)
    //     {
    //         if (string.IsNullOrEmpty(team.TeamName))
    //         {
    //             continue;
    //         }
    //         var teamEntity = await _teamRepository.GetTeamByNameAsync(team.TeamName);
    //         var players = await _playerRepository.GetTeamPlayersList(team.TeamId);
    //
    //         if (teamEntity == null)
    //         {
    //             teamEntity = new TeamEntity();
    //         }
    //
    //         _mapper.Map(teamEntity, team);
    //         await _teamRepository.SaveTeamAsync(teamEntity);
    //
    //         foreach (var player in players)
    //         {
    //             player.Team = teamEntity;
    //             await _playerRepository.SavePlayerAsync(player);
    //         }
    //     }
    // }
    
    private async Task<List<TeamData>> GetOpenDotaTeamsAsync()
    {
        List<TeamData> teamsList = new List<TeamData>();
        var page = 0;

        while (true)
        {
            var fetchedTeams = await _openDotaHttpClient.GetDataAsync<List<TeamData>>($"teams?page={page}");
            if (!fetchedTeams.Any())
            {
                break;
            }
            teamsList.AddRange(fetchedTeams);
            page++;
        }

        return teamsList;
    }
}