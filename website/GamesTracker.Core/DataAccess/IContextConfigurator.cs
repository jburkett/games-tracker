using Microsoft.EntityFrameworkCore;

namespace GamesTracker.Core.DataAccess;

public interface IContextConfigurator
{
    void ConfigureModel(ModelBuilder builder);
}
