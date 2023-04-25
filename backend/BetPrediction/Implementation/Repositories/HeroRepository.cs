using Implementation.Data;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Models.Entities;

namespace Implementation.Repositories;

public class HeroRepository: IHeroRepository
{
    private readonly DataBaseContext _context;
    
    public HeroRepository(DataBaseContext context)
    {
        _context = context;
    }

    public async Task<List<HeroEntity>> GetHeroesAsync()
    {
        return await _context.Heroes.ToListAsync();
    }

    public async Task<HeroEntity?> GetHeroByOpenDotaId(int openDotaId)
    {
        return await _context.Heroes.FirstOrDefaultAsync(hero => hero.OpenDotaId == openDotaId);
    }

    public async Task<HeroEntity?> GetHeroById(Guid id)
    {
        return await _context.Heroes.FirstOrDefaultAsync(hero => hero.Id == id);
    }

    public async Task SaveHeroesAsync(List<HeroEntity> heroesList)
    {
        foreach (var hero in heroesList)
        {
            if (hero.Id == default)
            {
                _context.Heroes.Add(hero);
            }
            else
            {
                _context.Heroes.Update(hero);
            }
        }
        
        
        await _context.SaveChangesAsync();
    }

    public async Task SaveHero(HeroEntity hero)
    {
        if (hero.Id == default)
        {
            _context.Heroes.Add(hero);
        }
        else
        {
            _context.Heroes.Update(hero);
        }
        
        await _context.SaveChangesAsync();
    }
}