using Implementation.Data;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Models.Entities;

namespace Implementation.Repositories;

public class TeamRepository: ITeamRepository
{
    
    private readonly DataBaseContext _context;

    public TeamRepository(DataBaseContext context)
    {
        _context = context;
    }
    
    public Task<List<TeamEntity>> GetTeamsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<TeamEntity?> GetTeamByNameAsync(string name)
    {
        return await _context.Teams.FirstOrDefaultAsync(team => team.TeamName == name);
    }

    public async Task SaveTeamAsync(TeamEntity teamEntity)
    {
        if (teamEntity.Id != default)
        {
            _context.Teams.Update(teamEntity);
        }
        else
        {
            _context.Teams.Add(teamEntity);
        }

        await _context.SaveChangesAsync();
    }

    public Task AddTeamsAsync(List<TeamEntity> teams)
    {
        throw new NotImplementedException();
    }
}