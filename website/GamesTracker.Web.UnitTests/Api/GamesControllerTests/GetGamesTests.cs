using GamesTracker.Core;
using GamesTracker.Web.Api;
using Microsoft.AspNetCore.Mvc;

namespace GamesTracker.Web.UnitTests.Api.GamesControllerTests;

public class GetGamesTests
{
    [Fact]
    public void Returns_200_On_Success()
    {
        var controller = new GamesController(GetSimpleGameManager());

        var response = controller.GetGames() as OkObjectResult;

        response.Should().NotBeNull();
    }

    [Fact]
    public void Returns_All_Games()
    {
        var controller = new GamesController(GetSimpleGameManager());

        var response = controller.GetGames() as OkObjectResult;
        var actual = response!.Value as Game[];

        actual!.Length.Should().Be(3);
    }

    private static IGameManager GetSimpleGameManager()
    {
        var gameManager = Substitute.For<IGameManager>();
        gameManager.GetGames().Returns([
            new Game { Id = 1, Name = "Chess" },
            new Game { Id = 2, Name = "Risk" },
            new Game { Id = 3, Name = "Scrabble" }
        ]);

        return gameManager;
    }
}