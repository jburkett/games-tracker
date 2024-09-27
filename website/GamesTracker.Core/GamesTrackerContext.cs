using Microsoft.EntityFrameworkCore;

namespace GamesTracker.Core;

public class GamesTrackerContext(DbContextOptions<GamesTrackerContext> options) : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
}
