using Microsoft.EntityFrameworkCore;

namespace GamesTracker.Core;

public class GamesTrackerContext : DbContext
{
    public DbSet<Game> Games => Set<Game>();
}
