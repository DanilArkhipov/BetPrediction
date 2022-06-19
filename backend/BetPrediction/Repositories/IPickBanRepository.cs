using Repositories.Models.Entities;

namespace Repositories;

public interface IPickBanRepository
{
    Task SavePickBanAsync(PickBanEntity pickBanEntity);

    Task SavePickBansAsync(List<PickBanEntity> pickBanEntities);

    Task<List<PickBanEntity>> GetPickBansByGameId(long gameId);

    Task<List<PickBanEntity>> GetPickBansForPeriod(DateOnly startPeriodDate, DateOnly endPeriodDate);
}