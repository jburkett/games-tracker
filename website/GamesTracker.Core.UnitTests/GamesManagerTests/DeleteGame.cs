using FluentAssertions;

namespace GamesTracker.Core.UnitTests.GamesManagerTests;

public class DeleteGame
{
    [Fact]
    public void Deletes_Game_From_Context()
    {
        var mother = new SqliteContextBuilder();
        var context = mother.AddBaselineGames().CreateContext();
        var manager = new GameManager(context);

        manager.DeleteGame(1);

        context.ChangeTracker.Clear();
        var actual = context.Games.Count();

        actual.Should().Be(2);
    }

    [Fact]
    public void Returns_True_If_Game_Found()
    {
        var mother = new SqliteContextBuilder();
        var context = mother.AddBaselineGames().CreateContext();
        var manager = new GameManager(context);

        var actual = manager.DeleteGame(2);

        actual.Should().BeTrue();
    }

    [Fact]
    public void Returns_False_If_Game_Not_Found()
    {
        var mother = new SqliteContextBuilder();
        var context = mother.AddBaselineGames().CreateContext();
        var manager = new GameManager(context);

        var actual = manager.DeleteGame(4);

        actual.Should().BeFalse();
    }
}