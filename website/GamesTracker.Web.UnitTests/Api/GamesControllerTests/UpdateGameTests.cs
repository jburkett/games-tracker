using GamesTracker.Core;
using GamesTracker.Web.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace GamesTracker.Web.UnitTests.Api.GamesControllerTests;

public class UpdateGameTests
{
    [Fact]
    public void Saves_Updated_Game()
    {
        var gameManager = Substitute.For<IGameManager>();
        var controller = new GamesController(gameManager);
        var game = new Game
        {
            Id = 1,
            Name = "Chess"
        };

        controller.UpdateGame(1, game);

        gameManager.Received().UpdateGame(game);
    }

    [Fact]
    public void Returns_204_For_Success()
    {
        var gameManager = Substitute.For<IGameManager>();
        var controller = new GamesController(gameManager);
        var game = new Game
        {
            Id = 1,
            Name = "Chess"
        };

        var actual = controller.UpdateGame(1, game) as NoContentResult;

        actual.Should().NotBeNull();
    }

    [Fact]
    public void Returns_400_For_Mismatched_Id()
    {
        var gameManager = Substitute.For<IGameManager>();
        var controller = new GamesController(gameManager);
        var game = new Game
        {
            Id = 1,
            Name = "Chess"
        };

        var actual = controller.UpdateGame(2, game) as BadRequestResult;

        actual.Should().NotBeNull();
    }

    [Fact]
    public void Returns_404_For_Invalid_Id()
    {
        var gameManager = Substitute.For<IGameManager>();

        gameManager.When(x => x.UpdateGame(Arg.Any<Game>()))
            .Throw(x => new DbUpdateConcurrencyException());

        var controller = new GamesController(gameManager);

        var game = new Game
        {
            Id = 99,
            Name = "Chess"
        };

        var actual = controller.UpdateGame(99, game) as NotFoundResult;

        actual.Should().NotBeNull();
        actual!.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }
}