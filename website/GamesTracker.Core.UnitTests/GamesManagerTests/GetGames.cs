namespace GamesTracker.Core.UnitTests.GamesManagerTests;

public class GetGames
{
    [Fact]
    public void Returns_All_Games()
    {
        var mother = new SqliteContextBuilder();
        var context = mother.AddBaselineGames().CreateContext();
        var manager = new GameManager(context);

        var games = manager.GetGames();

        games.Should().HaveCount(3);
    }
}
