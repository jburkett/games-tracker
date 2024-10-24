using GamesTracker.Core;
using Microsoft.AspNetCore.Mvc;

namespace GamesTracker.Web.Api;

[Route("api/[controller]")]
[ApiController]
public class GamesController(IGameManager gameManager) : ControllerBase
{
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
}
