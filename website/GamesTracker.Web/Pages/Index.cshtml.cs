using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GamesTracker.Web.Pages;

public class IndexModel : PageModel
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
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
    }
}
