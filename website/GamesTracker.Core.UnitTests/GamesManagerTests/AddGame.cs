using FluentAssertions;

namespace GamesTracker.Core.UnitTests.GamesManagerTests;

public class AddGame
{
    [Fact]
    public void Adds_Game_To_Context()
    {
        var mother = new SqliteContextBuilder();
        var context = mother.AddBaselineGames().CreateContext();
        var manager = new GameManager(context);

        manager.AddGame("New game", "");

        context.ChangeTracker.Clear();
        var actual = context.Games.Count();

        actual.Should().Be(4);
    }
}