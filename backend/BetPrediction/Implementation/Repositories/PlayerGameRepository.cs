using Implementation.Data;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Models.Entities;

namespace Implementation.Repositories;

public class PlayerGameRepository: IPlayerGameRepository
{
    private readonly DataBaseContext _context;

    public PlayerGameRepository(DataBaseContext context)
    {
        _context = context;
    }

    public async Task SavePlayerGameAsync(PlayerGameEntity playerGameEntity)
    {
        if (playerGameEntity.Id == default)
        {
            _context.PlayerGames.Add(playerGameEntity);
        }
        else
        {
            _context.PlayerGames.Update(playerGameEntity);
        }

        await _context.SaveChangesAsync();
    }
    
    public async Task SavePlayerGamesAsync(List<PlayerGameEntity> playerGameEntities)
    {
        foreach (var entity in playerGameEntities)
        {
            if (entity.Id == default)
            {
                _context.PlayerGames.Add(entity);
            }
            else
            {
                _context.PlayerGames.Update(entity);
            }
        }

        await _context.SaveChangesAsync();
    }

    public async Task<List<PlayerGameEntity>> GetPlayerGamesByGameId(long gameId)
    {
        return await _context.PlayerGames
            .Where(x => x.GameId == gameId)
            .ToListAsync();
    }
}