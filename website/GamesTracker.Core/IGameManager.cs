namespace GamesTracker.Core;

public interface IGameManager
{
    Game[] GetGames();
    Game? GetGame(int id);
    void UpdateGame(Game game);
    (bool IsSaved, Game NewGame) AddGame(string name, string description);
}
