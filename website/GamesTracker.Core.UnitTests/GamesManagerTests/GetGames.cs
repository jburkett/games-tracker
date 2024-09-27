using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace GamesTracker.Core.UnitTests.GamesManagerTests;

public class GetGames
{
    [Fact]
    public void Returns_All_Games()
    {
        var context = SqliteContextMother.CreateContext();
        context.Games.Add(new Game { Name = "Game 1" });
        context.Games.Add(new Game { Name = "Game 2" });
        context.Games.Add(new Game { Name = "Game 3" });
        context.SaveChanges();
        var manager = new GameManager(context);

        var games = manager.GetGames();

        games.Should().HaveCount(3);
    }
}

public static class SqliteContextMother
{
    public static GamesTrackerContext CreateContext()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<GamesTrackerContext>()
            .UseSqlite(connection)
            .Options;

        var context = new GamesTrackerContext(options);
        context.Database.EnsureDeletedAsync();
        context.Database.EnsureCreatedAsync();

        return context;
    }
}
