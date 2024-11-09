using GamesTracker.Core;
using GamesTracker.Web.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamesTracker.Web.UnitTests.Api.GamesControllerTests;

public class DeleteGameTests
{
    [Fact]
    public void Returns_200_For_Valid_Id()
    {
        var gameManager = Substitute.For<IGameManager>();

        gameManager.DeleteGame(Arg.Any<int>()).Returns(true);

        var controller = new GamesController(gameManager);

        var actual = controller.DeleteGame(1) as OkResult;

        actual.Should().NotBeNull();
        actual!.StatusCode.Should().Be(StatusCodes.Status200OK);
    }

    [Fact]
    public void Returns_404_For_Invalid_Id()
    {
        var gameManager = Substitute.For<IGameManager>();

        gameManager.DeleteGame(Arg.Any<int>()).Returns(false);

        var controller = new GamesController(gameManager);

        var actual = controller.DeleteGame(1) as NotFoundResult;

        actual.Should().NotBeNull();
        actual!.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }
}