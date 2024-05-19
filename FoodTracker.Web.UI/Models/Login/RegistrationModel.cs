namespace FoodTracker.Web.UI.Models.Login;

public class RegistrationModel
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public Guid Token { get; set; } = Guid.Empty;

    public bool IsEmpty => string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || Token == Guid.Empty;
}