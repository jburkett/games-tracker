using GamesTracker.Core;
using GamesTracker.Web.Pages;

namespace GamesTracker.Web.UnitTests.Pages.IndexTests;

public class OnGetTests
{
    /// <summary>
    /// Tests to ensure the three games set up in the test context are added to the page model.
    /// </summary>
    [Fact]
    public void Games_List_Should_Have_Three_Items()
    {
        var manager = Substitute.For<IGameManager>();
        manager.GetGames().Returns([
            new Game { Name = "Game 1" }, new Game { Name = "Game 2" }, new Game { Name = "Game 3" }
        ]);
        var page = new IndexModel(manager);
        page.OnGet();

        page.Games.Count.Should().Be(3);
    }
}
