using FoodTracker.Contracts.Persistence;
using FoodTracker.Data.Domain.Persistence.User;
using FoodTracker.Data.Persistence.Context;
using FoodTracker.Data.Persistence.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FoodTracker.Data.Persistence.Repositories;

internal class UserSettingsRepository : ISettingsRepository
{
    private readonly VoedingDbContext _context;

    public UserSettingsRepository(VoedingDbContext context)
    {
        _context = context;
    }

    public async Task<IUserSettingsEntity?> GetSettingsForUser(int userId)
    {
        return await _context.UserSettings.FirstOrDefaultAsync(x => x.UserId == userId);
    }

    public async Task CreateOrUpdate(int userId, double energyGoal, double proteinGoal, double fatGoal, double carbGoal)
    {
        var userSettings = await _context.UserSettings.FirstOrDefaultAsync(x => x.UserId == userId);
        if (userSettings == null)
        {
            userSettings = new UserSettingsEntity()
            {
                CarbGoal = carbGoal,
                UserId = userId,
                CreatedOnUtc = DateTime.UtcNow,
                EnergyGoal = energyGoal,
                ProteinGoal = proteinGoal,
                FatGoal = fatGoal,
                LastUpdatedOnUtc = DateTime.UtcNow,
            };
        }
        else
        {
            userSettings.EnergyGoal = energyGoal;
            userSettings.ProteinGoal = proteinGoal;
            userSettings.CarbGoal = carbGoal;
            userSettings.FatGoal = fatGoal;
            userSettings.LastUpdatedOnUtc = DateTime.UtcNow;
        }

        _context.Update(userSettings);
        await _context.SaveChangesAsync();
    }
}