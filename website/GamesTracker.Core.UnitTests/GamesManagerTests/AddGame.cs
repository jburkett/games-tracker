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

    [Fact]
    public void Returns_IsSaved_True_When_Succeeds()
    {
        var mother = new SqliteContextBuilder();
        var context = mother.AddBaselineGames().CreateContext();
        var manager = new GameManager(context);

        var result = manager.AddGame("New game", "");

        result.IsSaved.Should().BeTrue();
    }

    [Fact]
    public void Returns_Game_With_New_Id_When_Succeeds()
    {
        var mother = new SqliteContextBuilder();
        var context = mother.AddBaselineGames().CreateContext();
        var manager = new GameManager(context);

        var result = manager.AddGame("New game", "");

        result.NewGame.Id.Should().Be(4);
    }
}