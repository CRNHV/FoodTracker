using System.Text.Json.Serialization;

namespace FoodTracker.Web.UI.Models.Login;

public class JwtToken
{
    [JsonPropertyName("token")]
    public string? Token { get; set; }
}