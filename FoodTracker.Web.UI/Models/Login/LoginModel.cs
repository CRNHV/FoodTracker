namespace FoodTracker.Web.UI.Models.Login;

public class LoginModel
{
    public string? Username { get; set; }
    public string? Password { get; set; }

    public bool IsEmpty => string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password);
}