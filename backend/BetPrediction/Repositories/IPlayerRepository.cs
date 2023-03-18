using Repositories.Models.Entities;

namespace Repositories;

public interface IPlayerRepository
{
    Task<List<PlayerEntity>> GetPlayersAsync();

    Task<PlayerEntity?> GetPlayerByNameAsync(string name);

    Task<List<PlayerEntity>> GetTeamPlayersList(int teamId);

    Task SavePlayerAsync(PlayerEntity playerEntity);

    Task AddPlayersAsync(List<PlayerEntity> players);
}