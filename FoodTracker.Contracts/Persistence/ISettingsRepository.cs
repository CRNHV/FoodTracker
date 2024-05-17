using FoodTracker.Data.Domain.Persistence.User;
using System.Threading.Tasks;

namespace FoodTracker.Contracts.Persistence;

public interface ISettingsRepository
{
    Task<IUserSettingsEntity?> GetSettingsForUser(int userId);

    Task CreateOrUpdate(int userId, double energyGoal, double proteinGoal, double fatGoal, double carbGoal);
}