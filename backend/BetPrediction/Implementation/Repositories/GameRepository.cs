using Implementation.Data;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Models.Entities;

namespace Implementation.Repositories;

public class GameRepository : IGameRepository
{
    private readonly DataBaseContext _context;

    public GameRepository(DataBaseContext context)
    {
        _context = context;
    }

    public async Task<GameEntity?> GetGameByIdAsync(long gameId)
    {
        return await _context.Games
            .FirstOrDefaultAsync(x => x.MatchId == gameId);
    }

    public async Task SaveGameAsync(GameEntity gameEntity)
    {
        if (gameEntity.Id == default)
            _context.Games.Add(gameEntity);
        else
            _context.Games.Update(gameEntity);

        await _context.SaveChangesAsync();
    }

    public async Task<List<GameEntity>> GetGamesAsync()
    {
        return await _context.Games.ToListAsync();
    }
}