using FoodTracker.Application.Extensions.Mappings;
using FoodTracker.Contracts.Application.User;
using FoodTracker.Contracts.Persistence;
using FoodTracker.Data.Domain.Application.User;
using System;
using System.Threading.Tasks;

namespace FoodTracker.Application.User;
internal class RegistrationTokenService : IRegistrationTokens
{
    private readonly IRegistrationTokenRepository _repository;

    public RegistrationTokenService(IRegistrationTokenRepository repository)
    {
        _repository = repository;
    }

    public async Task<IRegistrationToken> CreateTokenAsync()
    {
        var token = await _repository.CreateTokenAsync();
        return token.ToDomain();
    }

    public async Task<IRegistrationToken?> GetTokenAsync(Guid tokenId)
    {
        var registrationToken = await _repository.GetRegistrationTokenAsync(tokenId);
        if (registrationToken == null)
            return null;
        return registrationToken.ToDomain();
    }

    public async Task SetTokenUsedAsync(Guid tokenId)
    {
        await _repository.SetTokenUsedAsync(tokenId);
    }
}
