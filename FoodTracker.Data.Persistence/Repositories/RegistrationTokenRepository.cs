using FoodTracker.Contracts.Persistence;
using FoodTracker.Data.Domain.Persistence.User;
using FoodTracker.Data.Persistence.Context;
using FoodTracker.Data.Persistence.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FoodTracker.Data.Persistence.Repositories;
internal class RegistrationTokenRepository : IRegistrationTokenRepository
{
    private readonly FoodTrackerDbContext _context;

    public RegistrationTokenRepository(FoodTrackerDbContext context)
    {
        _context = context;
    }

    public async Task<IRegistrationTokenEntity> CreateTokenAsync()
    {
        var token = new RegistrationTokenEntity()
        {
            CreatedOnUtc = DateTime.UtcNow,
            LastUpdatedOnUtc = DateTime.UtcNow,
            Token = Guid.NewGuid()
        };

        await _context.AddAsync(token);
        await _context.SaveChangesAsync();

        return token;
    }

    public async Task<IRegistrationTokenEntity?> GetRegistrationTokenAsync(Guid tokenId)
    {
        return await _context.RegistrationTokens.FirstOrDefaultAsync(x => x.Token == tokenId);
    }

    public async Task SetTokenUsedAsync(Guid tokenId)
    {
        var token = await _context.RegistrationTokens.FirstOrDefaultAsync(x => x.Token == tokenId);
        if (token is null)
            return;

        token.LastUpdatedOnUtc = DateTime.UtcNow;
        await _context.SaveChangesAsync();
    }
}
