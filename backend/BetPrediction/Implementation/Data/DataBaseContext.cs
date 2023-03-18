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
}