using Implementation.OpenDotaApi.Models.Responses;
using Microsoft.EntityFrameworkCore;
using Repositories.Models.Entities;

namespace Implementation.Data;

public class DataBaseContext: DbContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
    {
    }

    public DbSet<PlayerEntity> Players { get; set; }
    
    public DbSet<TeamEntity> Teams { get; set; }
    
    public DbSet<HeroEntity> Heroes { get; set; }
    
    public DbSet<PatchEntity> Patches { get; set; }
    
    public DbSet<PlayerGameEntity> PlayerGames { get; set; }
    
    public DbSet<PickBanEntity> PickBans { get; set; }
    
    public DbSet<LeagueEntity> Leagues { get; set; }
    
    public DbSet<GameEntity> Games { get; set; }

}