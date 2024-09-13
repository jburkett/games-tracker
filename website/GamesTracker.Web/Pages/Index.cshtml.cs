using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GamesTracker.Web.Pages;

public class IndexModel(ILogger<IndexModel> logger) : PageModel
{
    public List<GameModel> Games { get; set; } = [];

    public void OnGet()
    {
        Games =
        [
            new GameModel { Id = 1, Name = "Catan", Description = "A simple board game" },
            new GameModel { Id = 2, Name = "Risk", Description = "An absurd board game" },
            new GameModel { Id = 3, Name = "Scrabble", Description = "A game of words" }
        ];
    }

    public class GameModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
