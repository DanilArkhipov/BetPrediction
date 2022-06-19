using Repositories.Models.Entities;

namespace Repositories;

public interface IPlayerGameRepository
{
     Task SavePlayerGameAsync(PlayerGameEntity playerGameEntity);
     
     Task SavePlayerGamesAsync(List<PlayerGameEntity> playerGameEntities);

     Task<List<PlayerGameEntity>> GetPlayerGamesByGameId(long gameId);
     
     Task<List<PlayerGameEntity>> GetPlayerGamesAsync();
}