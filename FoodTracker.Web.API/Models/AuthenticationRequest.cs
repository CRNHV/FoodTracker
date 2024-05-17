namespace FoodTracker.Web.API.Models;

public record AuthenticationRequest
{
    public string Username { get; init; }
    public string Password { get; init; }
}