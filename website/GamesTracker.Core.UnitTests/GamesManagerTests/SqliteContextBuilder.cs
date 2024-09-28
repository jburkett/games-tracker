using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace GamesTracker.Core.UnitTests.GamesManagerTests;

public class SqliteContextBuilder
{
    private readonly GamesTrackerContext _context;

    public SqliteContextBuilder()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<GamesTrackerContext>()
            .UseSqlite(connection)
            .Options;

        _context = new GamesTrackerContext(options);

        Reset();
    }

    public GamesTrackerContext CreateContext()
    {
        return _context;
    }

    private SqliteContextBuilder Reset()
    {
        _context.Database.EnsureDeletedAsync();
        _context.Database.EnsureCreatedAsync();

        return this;
    }

    public SqliteContextBuilder AddBaselineGames()
    {
        Game[] games =
        [
            new() { Id = 1, Name = "Catan", Description = "A simple board game" },
            new() { Id = 2, Name = "Risk", Description = "An absurd board game" },
            new() { Id = 3, Name = "Scrabble", Description = "A game of words" }
        ];

        _context.Games.AddRange(games);
        _context.SaveChanges();

        return this;
    }
}
