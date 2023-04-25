using Repositories.Models.Entities;

namespace Repositories;

public interface ILeagueRepository
{
    Task SaveLeague(LeagueEntity leagueEntity);

    Task<LeagueEntity?> GetLeagueByLeagueId(long leagueId);
}