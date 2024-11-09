namespace GamesTracker.Web.Api;

public record AddGameRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}