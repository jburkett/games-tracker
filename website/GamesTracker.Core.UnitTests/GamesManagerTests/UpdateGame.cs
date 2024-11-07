using FluentAssertions;

namespace GamesTracker.Core.UnitTests.GamesManagerTests;

public class UpdateGame
{
    [Fact]
    public void Database_Not_Updated_If_UpdateGame_Not_Called()
    {
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

        actual!.Name.Should().Be("New Title"); // This is checking to make sure the game was not updated
    }
}