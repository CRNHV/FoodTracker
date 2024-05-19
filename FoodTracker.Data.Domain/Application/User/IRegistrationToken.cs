using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Data.Domain.Application.User;
public interface IRegistrationToken
{
    public Guid Token { get; init; }
    public bool IsUsed { get; init; }
}
