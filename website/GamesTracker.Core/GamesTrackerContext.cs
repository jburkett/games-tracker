using GamesTracker.Core.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace GamesTracker.Core;

public class GamesTrackerContext(DbContextOptions<GamesTrackerContext> options, IContextConfigurator configurator)
    : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        configurator.ConfigureModel(modelBuilder);
    }
}
