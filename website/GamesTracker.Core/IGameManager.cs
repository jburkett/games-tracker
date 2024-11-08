namespace GamesTracker.Core;

public interface IGameManager
{
    Game[] GetGames();
    Game? GetGame(int id);
    void UpdateGame(Game game);
    void AddGame(string name, string description);
}
