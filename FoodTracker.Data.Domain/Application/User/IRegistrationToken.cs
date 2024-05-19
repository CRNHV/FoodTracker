using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Data.Domain.Application.User;
public interface IRegistrationToken
{
    public Guid Token { get; set; }
    public bool IsUsed { get; set; }
}
