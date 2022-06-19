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
            _context.PickBans.Add(pickBanEntity);
        else
            _context.PickBans.Update(pickBanEntity);

        await _context.SaveChangesAsync();
    }

    public async Task SavePickBansAsync(List<PickBanEntity> pickBanEntities)
    {
        foreach (var pickBanEntity in pickBanEntities)
            if (pickBanEntity.Id == default)
                _context.PickBans.Add(pickBanEntity);
            else
                _context.PickBans.Update(pickBanEntity);

        await _context.SaveChangesAsync();
    }

    public async Task<List<PickBanEntity>> GetPickBansByGameId(long gameId)
    {
        return await _context.PickBans
            .Where(x => x.GameId == gameId)
            .ToListAsync();
    }

    public async Task<List<PickBanEntity>> GetPickBansForPeriod(DateOnly startPeriodDate, DateOnly endPeriodDate)
    {
        var unixStartDate =
            new DateTimeOffset(new DateTime(startPeriodDate.Year, startPeriodDate.Month, startPeriodDate.Day))
                .ToUnixTimeSeconds();
        var unixEndDate =
            new DateTimeOffset(new DateTime(endPeriodDate.Year, endPeriodDate.Month, endPeriodDate.Day, 23, 59, 59))
                .ToUnixTimeSeconds();

        return await _context.Games
            .Where(x => x.StartTime <= unixStartDate && x.StartTime >= unixEndDate)
            .Join(_context.PickBans, game => game.MatchId, pickBan => pickBan.GameId, (game, pickBan) =>
                pickBan)
            .ToListAsync();
    }
}