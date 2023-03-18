using Implementation.Data;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Models.Entities;

namespace Implementation.Repositories;

public class PlayerRepository : IPlayerRepository
{
    private readonly DataBaseContext _context;

    public PlayerRepository(DataBaseContext context)
    {
        _context = context;
    }

    public async Task<List<PlayerEntity>> GetPlayersAsync()
    {
        return await _context.Players.ToListAsync();
    }

    public async Task<PlayerEntity?> GetPlayerByNameAsync(string name)
    {
        return await _context.Players
            .FirstOrDefaultAsync(player => player.Name == name);
    }

    public async Task<List<PlayerEntity>> GetTeamPlayersList(int teamId)
    {
        return await _context.Players.Where(player => player.TeamId == teamId)
            .ToListAsync();
    }

    public async Task SavePlayerAsync(PlayerEntity playerEntity)
    {
        if (playerEntity.Id == default)
        {
            _context.Players.Add(playerEntity);
        }
        else
        {
            _context.Players.Update(playerEntity);
        }

        await _context.SaveChangesAsync();
    }

    public async Task AddPlayersAsync(List<PlayerEntity> players)
    {
        _context.Players.AddRange(players);
        await _context.SaveChangesAsync();
    }
}