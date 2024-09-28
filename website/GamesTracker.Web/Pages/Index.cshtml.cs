using GamesTracker.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GamesTracker.Web.Pages;

public class IndexModel(IGameManager gameManager) : PageModel
{
    private readonly IGameManager _gameManager = gameManager;

    public List<Game> Games { get; set; } = [];

    public void OnGet()
    {
        Games = _gameManager.GetGames().ToList();
    }
}
