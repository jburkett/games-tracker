using GamesTracker.Core.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace GamesTracker.Core.UnitTests;

internal class SqliteContextConfigurator : IContextConfigurator
{
    public void ConfigureModel(ModelBuilder builder)
    {
        builder.Entity<Game>()
            .HasKey(x => x.Id);
        builder.Entity<Game>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();
    }
}