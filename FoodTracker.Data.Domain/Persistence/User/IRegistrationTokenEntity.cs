using System;

namespace FoodTracker.Data.Domain.Persistence.User;
public interface IRegistrationTokenEntity : IEntityBase
{
    Guid Token { get; set; }
}
