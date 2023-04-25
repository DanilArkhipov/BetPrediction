using Implementation.Data;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Models.Entities;

namespace Implementation.Repositories;

public class PickBanRepository : IPickBanRepository
{
    private readonly DataBaseContext _context;

    public PickBanRepository(DataBaseContext context)
    {
        _context = context;
    }

    public async Task SavePickBanAsync(PickBanEntity pickBanEntity)
    {
        if (pickBanEntity.Id == default)
        {
            _context.PickBans.Add(pickBanEntity);
        }
        else
        {
            _context.PickBans.Update(pickBanEntity);
        }

        await _context.SaveChangesAsync();
    }

    public async Task SavePickBansAsync(List<PickBanEntity> pickBanEntities)
    {
        foreach (var pickBanEntity in pickBanEntities)
        {
            if (pickBanEntity.Id == default)
            {
                _context.PickBans.Add(pickBanEntity);
            }
            else
            {
                _context.PickBans.Update(pickBanEntity);
            }
        }
        
        await _context.SaveChangesAsync();
    }

    public async Task<List<PickBanEntity>> GetPickBansByGameId(long gameId)
    {
        return await _context.PickBans
            .Where(x => x.GameId == gameId)
            .ToListAsync();
    }
}