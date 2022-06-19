using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repositories.Models.Entities;

namespace Implementation.Data;

public class DataBaseContext : IdentityDbContext<UserEntity>
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
    {
    }

    public DbSet<AdminLogEntity> AdminLogs { get; set; }

    public DbSet<PlayerEntity> Players { get; set; }

    public DbSet<TeamEntity> Teams { get; set; }

    public DbSet<HeroEntity> Heroes { get; set; }

    public DbSet<PatchEntity> Patches { get; set; }

    public DbSet<PlayerGameEntity> PlayerGames { get; set; }

    public DbSet<PickBanEntity> PickBans { get; set; }

    public DbSet<LeagueEntity> Leagues { get; set; }

    public DbSet<GameEntity> Games { get; set; }
}