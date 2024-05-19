using FoodTracker.Data.Domain.Persistence.User;
using System;
using System.Threading.Tasks;

namespace FoodTracker.Contracts.Persistence;
public interface IRegistrationTokenRepository
{
    Task<IRegistrationTokenEntity> CreateTokenAsync();
    Task<IRegistrationTokenEntity> GetRegistrationTokenAsync(Guid tokenId);
}
