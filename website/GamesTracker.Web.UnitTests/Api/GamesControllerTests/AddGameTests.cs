using GamesTracker.Core;
using GamesTracker.Web.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace GamesTracker.Web.UnitTests.Api.GamesControllerTests;

public class AddGameTests
{
    [Fact]
    public void Saves_New_Game()
    {
        var request = new AddGameRequest
        {
            Name = "game name",
            Description = "game description"
        };

        var gameManager = Substitute.For<IGameManager>();
        gameManager.AddGame(Arg.Any<string>(), Arg.Any<string>())
            .Returns((true, new Game { Id = 4 }));
        var controller = new GamesController(gameManager);

        controller.AddGame(request);

        gameManager.Received().AddGame("game name", "game description");
    }

    [Fact]
    public void Returns_Created()
    {
        var request = new AddGameRequest
        {
            Name = "game name",
            Description = "game description"
        };

        var gameManager = Substitute.For<IGameManager>();
        gameManager.AddGame(Arg.Any<string>(), Arg.Any<string>())
            .Returns((true, new Game { Id = 4 }));
        var controller = new GamesController(gameManager);

        var response = controller.AddGame(request) as CreatedResult;

        response.Should().NotBeNull();
        response!.StatusCode.Should().Be(StatusCodes.Status201Created);
    }

    [Fact]
    public void Returns_Correct_Location()
    {
        var request = new AddGameRequest
        {
            Name = "game name",
            Description = "game description"
        };

        var gameManager = Substitute.For<IGameManager>();
        gameManager.AddGame(Arg.Any<string>(), Arg.Any<string>())
            .Returns((true, new Game { Id = 4 }));
        var controller = new GamesController(gameManager);

        var response = controller.AddGame(request) as CreatedResult;

        response.Should().NotBeNull();
        response!.Location.Should().Be("/api/games/4");
    }

    [Fact]
    public void Returns_New_Game()
    {
        var request = new AddGameRequest
        {
            Name = "game name",
            Description = "game description"
        };

        var gameManager = Substitute.For<IGameManager>();
        gameManager.AddGame(Arg.Any<string>(), Arg.Any<string>())
            .Returns((true, new Game { Id = 4 }));
        var controller = new GamesController(gameManager);

        var response = controller.AddGame(request) as CreatedResult;
        var actual = response!.Value as Game;

        actual!.Id.Should().Be(4);
    }
}