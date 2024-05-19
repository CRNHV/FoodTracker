using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Data.Domain.Persistence.User;
public interface IRegistrationTokenEntity : IEntityBase
{
    Guid Token { get; set; }
}
