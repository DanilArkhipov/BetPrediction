using Repositories.Models.Entities;

namespace Repositories;

public interface ITeamRepository
{
    Task<List<TeamEntity>> GetTeamsAsync();

    Task<TeamEntity?> GetTeamByNameAsync(string name);

    Task SaveTeamAsync(TeamEntity teamEntity);

    Task SaveTeamsAsync(List<TeamEntity> teamEntities);

    Task AddTeamsAsync(List<TeamEntity> teams);

    Task<TeamEntity?> GetTeamByOpenDotaId(long id);
}