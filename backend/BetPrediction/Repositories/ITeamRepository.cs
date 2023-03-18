using Repositories.Models.Entities;

namespace Repositories;

public interface ITeamRepository
{
    Task<List<TeamEntity>> GetTeamsAsync();

    Task<TeamEntity?> GetTeamByNameAsync(string name);

    Task SaveTeamAsync(TeamEntity teamEntity);

    Task AddTeamsAsync(List<TeamEntity> teams);
}