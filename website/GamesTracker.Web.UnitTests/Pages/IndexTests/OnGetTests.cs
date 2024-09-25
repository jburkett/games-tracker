using GamesTracker.Web.Pages;

namespace GamesTracker.Web.UnitTests.Pages.IndexTests;

public class OnGetTests
{
    [Fact]
    public void Games_List_Should_Have_Three_Items()
    {
        var page = new IndexModel();
        page.OnGet();

        page.Games.Count.Should().Be(3);
    }
}
