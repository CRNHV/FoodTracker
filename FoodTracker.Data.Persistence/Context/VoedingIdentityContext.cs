using FoodTracker.Data.Persistence.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodTracker.Data.Persistence.Context;

public class VoedingIdentityContext : IdentityDbContext<User, Role, int>
{
    public VoedingIdentityContext(DbContextOptions<VoedingIdentityContext> options) : base(options)
    {
    }
}