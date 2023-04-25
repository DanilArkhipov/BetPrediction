using Implementation.Data;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Models.Entities;

namespace Implementation.Repositories;

public class LeagueRepository: ILeagueRepository
{
    private readonly DataBaseContext _context;

    public LeagueRepository(DataBaseContext context)
    {
        _context = context;
    }

    public async Task SaveLeague(LeagueEntity leagueEntity)
    {
        if (leagueEntity.Id == default)
        {
            _context.Leagues.Add(leagueEntity);
        }
        else
        {
            _context.Leagues.Update(leagueEntity);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<LeagueEntity?> GetLeagueByLeagueId(long leagueId)
    {
        return await _context.Leagues.FirstOrDefaultAsync(x => x.LeagueId == leagueId);
    }
}