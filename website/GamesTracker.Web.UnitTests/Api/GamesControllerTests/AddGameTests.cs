using GamesTracker.Core;
using GamesTracker.Web.Api;
using NSubstitute;

namespace GamesTracker.Web.UnitTests.Api.GamesControllerTests;

public class AddGameTests
{
    [Fact]
    public void Saves_New_Game()
    {
        var gameManager = Substitute.For<IGameManager>();
        var controller = new GamesController(gameManager);
        var request = new AddGameRequest
        {
            Name = "game name",
            Description = "game description"
        };

        controller.AddGame(request);

        gameManager.Received().AddGame("game name", "game description");
    }
}