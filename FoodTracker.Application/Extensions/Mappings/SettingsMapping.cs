using FoodTracker.Application.User;
using FoodTracker.Data.Domain.Application.User;
using FoodTracker.Data.Domain.Persistence.User;

namespace FoodTracker.Application.Extensions.Mappings;

internal static class SettingsMapping
{
    public static IUserSettings ToDomainModel(this IUserSettingsEntity entity)
    {
        return new UserSettings()
        {
            CarbGoal = entity.CarbGoal,
            EnergyGoal = entity.EnergyGoal,
            FatGoal = entity.FatGoal,
            ProteinGoal = entity.ProteinGoal,
        };
    }
}