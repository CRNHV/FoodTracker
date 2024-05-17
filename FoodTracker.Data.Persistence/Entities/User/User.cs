using Microsoft.AspNetCore.Identity;

namespace FoodTracker.Data.Persistence.Entities.User;

public sealed class User : IdentityUser<int>
{
    public bool IsAdmin { get; set; }
}