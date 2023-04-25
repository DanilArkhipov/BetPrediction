using Repositories.Models.Entities;

namespace Repositories;

public interface IHeroRepository
{
    Task<List<HeroEntity>> GetHeroesAsync();

    Task<HeroEntity?> GetHeroByOpenDotaId(int openDotaId);

    Task<HeroEntity?> GetHeroById(Guid id);

    Task SaveHeroesAsync(List<HeroEntity> heroesList);

    Task SaveHero(HeroEntity hero);
}