using FoodTracker.Application.User.Models;
using FoodTracker.Data.Domain.Application.User;
using FoodTracker.Data.Domain.Persistence.User;

namespace FoodTracker.Application.Extensions.Mappings;
internal static class RegistrationTokenMapping
{
    public static IRegistrationToken ToDomain(this IRegistrationTokenEntity entity)
    {
        return new RegistrationToken()
        {
            Token = entity.Token,
            IsUsed = entity.CreatedOnUtc == entity.LastUpdatedOnUtc,
        };
    }
}
