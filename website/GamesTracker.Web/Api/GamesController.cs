using GamesTracker.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamesTracker.Web.Api;

[Route("api/[controller]")]
[ApiController]
public class GamesController(IGameManager gameManager) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetGames()
    {
        return Ok(_gameManager.GetGames());
    }

    private readonly IGameManager _gameManager = gameManager;

    [HttpGet("{id}")]
    [ProducesResponseType<Game>(StatusCodes.Status200OK)]
    [ProducesResponseType<Game>(StatusCodes.Status404NotFound)]
    public IActionResult GetGame(int id)
    {
        var game = _gameManager.GetGame(id);
        if (game == null)
        {
            return NotFound();
        }

        return Ok(game);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult UpdateGame(int id, Game game)
    {
        if (id != game.Id) return BadRequest();

        try
        {
            _gameManager.UpdateGame(game);
            return NoContent();
        }
        catch (DbUpdateConcurrencyException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AddGame([FromBody] AddGameRequest request)
    {
        var result =_gameManager.AddGame(request.Name, request.Description);
        return Created($"/api/games/{result.NewGame.Id}", null);
    }
}