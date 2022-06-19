using Repositories.Models.Entities;

namespace Repositories;

public interface IGameRepository
{
    Task<GameEntity?> GetGameByIdAsync(long gameId);

    Task SaveGameAsync(GameEntity gameEntity);

    Task<List<GameEntity>> GetGamesAsync();
}