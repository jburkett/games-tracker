namespace GamesTracker.Core.UnitTests.GamesManagerTests;

public class GetGame
{
    [Fact]
    public void Returns_Game_With_Specified_Id()
    {
        var mother = new SqliteContextBuilder();
        var context = mother.AddBaselineGames().CreateContext();
        var manager = new GameManager(context);

        var game = manager.GetGame(2);

        game!.Id.Should().Be(2);
    }

    [Fact]
    public void Returns_Null_When_Game_Not_Found()
    {
        var mother = new SqliteContextBuilder();
        var context = mother.AddBaselineGames().CreateContext();
        var manager = new GameManager(context);

        var game = manager.GetGame(4);

        game.Should().BeNull();
    }
}