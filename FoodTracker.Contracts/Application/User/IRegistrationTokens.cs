using FoodTracker.Data.Domain.Application.User;
using System;
using System.Threading.Tasks;

namespace FoodTracker.Contracts.Application.User;
public interface IRegistrationTokens
{
    Task<IRegistrationToken> CreateTokenAsync();
    Task<IRegistrationToken?> GetTokenAsync(Guid tokenId);
    Task SetTokenUsedAsync(Guid tokenId);
}
