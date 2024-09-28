using GamesTracker.Core.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace GamesTracker.DataAccess.Postgres;

public class PostgresContextConfigurator : IContextConfigurator
{
    public void ConfigureModel(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(PostgresContextConfigurator).Assembly);
    }
}
