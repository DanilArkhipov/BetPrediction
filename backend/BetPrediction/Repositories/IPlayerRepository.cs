using Repositories.Models.Entities;

namespace Repositories;

public interface IPlayerRepository
{
    Task<List<PlayerEntity>> GetPlayersAsync();

    Task<PlayerEntity?> GetPlayerByNameAsync(string name);

    Task<PlayerEntity?> GetPlayerByAccountId(long accountId);

    Task<List<PlayerEntity>> GetTeamPlayersList(long teamId);

    Task SavePlayerAsync(PlayerEntity playerEntity);

    Task SavePlayersAsync(List<PlayerEntity> playerEntities);

    Task AddPlayersAsync(List<PlayerEntity> players);
}