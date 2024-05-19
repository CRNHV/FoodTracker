using System;

namespace FoodTracker.Data.Domain.Application.User;
public interface IRegistrationToken
{
    public Guid Token { get; init; }
    public bool IsUsed { get; init; }
}
