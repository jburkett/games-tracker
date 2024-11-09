using GamesTracker.Core;
using GamesTracker.Web.Api;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace GamesTracker.Web.UnitTests.Api.GamesControllerTests;

public class GetGameTests
{
    [Fact]
    public void Returns_200_For_Valid_Id()
    {
        var controller = new GamesController(GetSimpleGameManager());

        var actual = controller.GetGame(1) as OkObjectResult;

        actual.Should().NotBeNull();
    }
    [Fact]

    public void Returns_404_For_Invalid_Id()
    {
        var controller = new GamesController(GetSimpleGameManager());

        var actual = controller.GetGame(24) as NotFoundResult;

        actual.Should().NotBeNull();
    }

    [Fact]
    public void Returns_Value_Of_Game()
    {
        var controller = new GamesController(GetSimpleGameManager());

        var result = controller.GetGame(1) as OkObjectResult;
        var actual = result!.Value as Game;

        actual.Should().NotBeNull();
    }

    [Theory]
    [InlineData(1, "Chess")]
    [InlineData(2, "Risk")]
    [InlineData(3, "Scrabble")]
    public void Returns_CorrectGame(int id, string expected)
    {
        var controller = new GamesController(GetSimpleGameManager());

        var response = controller.GetGame(id) as OkObjectResult;
        var actual = response!.Value as Game;
        actual!.Name.Should().Be(expected);
    }

    private static IGameManager GetSimpleGameManager()
    {
        var gameManager = Substitute.For<IGameManager>();
        gameManager.GetGame(1).Returns(new Game
        {
            Id = 1,
            Name = "Chess"
        });
        gameManager.GetGame(2).Returns(new Game
        {
            Id = 2,
            Name = "Risk"
        });
        gameManager.GetGame(3).Returns(new Game
        {
            Id = 3,
            Name = "Scrabble"
        });

        return gameManager;
    }
}