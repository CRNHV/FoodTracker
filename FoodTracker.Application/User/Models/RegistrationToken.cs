using FoodTracker.Data.Domain.Application.User;
using System;

namespace FoodTracker.Application.User.Models;
internal class RegistrationToken : IRegistrationToken
{    
    public Guid Token { get; set; }
    public bool IsUsed { get; set; }
}
