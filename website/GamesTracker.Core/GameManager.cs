namespace GamesTracker.Core;

public class GameManager(GamesTrackerContext gamesTrackerContext) : IGameManager
{
    private readonly GamesTrackerContext _gamesTrackerContext = gamesTrackerContext;

    public Game[] GetGames()
    {
        return _gamesTrackerContext.Games.ToArray();
    }

    public Game? GetGame(int id)
    {
        return _gamesTrackerContext.Games.Find(id);
    }
}
