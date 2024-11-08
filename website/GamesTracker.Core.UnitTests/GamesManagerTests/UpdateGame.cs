using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace GamesTracker.Core.UnitTests.GamesManagerTests;

public class UpdateGame
{
    [Fact]
    public void Database_Not_Updated_If_UpdateGame_Not_Called()
    {
        // This test is mainly a health check for the in memory database.

        var mother = new SqliteContextBuilder();
        var context = mother.AddBaselineGames().CreateContext();
        var manager = new GameManager(context);

        var game = manager.GetGame(2);
        game!.Name = "New Title";

        context.ChangeTracker.Clear();
        var actual = context.Games.SingleOrDefault(x => x.Id == 2);

        actual!.Name.Should().Be("Risk"); // This is checking to make sure the game was not updated
    }

    [Fact]
    public void Updates_Game_In_Context()
    {
        var mother = new SqliteContextBuilder();
        var context = mother.AddBaselineGames().CreateContext();
        var manager = new GameManager(context);

        var game = manager.GetGame(2);
        game!.Name = "New Title";

        manager.UpdateGame(game);

        context.ChangeTracker.Clear();
        var actual = context.Games.SingleOrDefault(x => x.Id == 2);

        actual!.Name.Should().Be("New Title");
    }

    [Fact]
    public void Throws_Exception_If_Game_Not_Found()
    {
        var mother = new SqliteContextBuilder();
        var context = mother.AddBaselineGames().CreateContext();
        var manager = new GameManager(context);

        var game = new Game
        {
            Id = 99,
            Name = "New Title"
        };

        context.ChangeTracker.Clear();

        var act = () => manager.UpdateGame(game);

        act.Should().Throw<DbUpdateConcurrencyException>();
    }
}