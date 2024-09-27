namespace GamesTracker.Core;

public class GameManager(GamesTrackerContext gamesTrackerContext) : IGameManager
{
    private readonly GamesTrackerContext _gamesTrackerContext = gamesTrackerContext;

    public Game[] GetGames()
    {
        return _gamesTrackerContext.Games.ToArray();
    }
}
