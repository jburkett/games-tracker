using GamesTracker.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GamesTracker.Web.Pages;

public class IndexModel : PageModel
{
    public List<Game> Games { get; set; } = [];

    public void OnGet()
    {
        Games =
        [
            new Game { Id = 1, Name = "Catan", Description = "A simple board game" },
            new Game { Id = 2, Name = "Risk", Description = "An absurd board game" },
            new Game { Id = 3, Name = "Scrabble", Description = "A game of words" }
        ];
    }
}
