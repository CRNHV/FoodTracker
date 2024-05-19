using System;

namespace FoodTracker.Web.API.Models;

public class RegistrationRequest
{
    public Guid Token { get; set; }
    public string Username { get; init; }
    public string Password { get; init; }
}
