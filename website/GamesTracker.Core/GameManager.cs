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

    public (bool IsSaved, Game NewGame) AddGame(string name, string description)
    {
        var game = new Game
        {
            Name = name,
            Description = description
        };

        var x =_gamesTrackerContext.Games.Add(game);
        _gamesTrackerContext.SaveChanges();

        return (true, x.Entity);
    }

    public void UpdateGame(Game game)
    {
        _gamesTrackerContext.Games.Update(game);
        _gamesTrackerContext.SaveChanges();
    }
}