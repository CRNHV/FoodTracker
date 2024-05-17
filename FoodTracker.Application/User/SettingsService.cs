using FoodTracker.Application.Extensions.Mappings;
using FoodTracker.Contracts.Application.User;
using FoodTracker.Contracts.Persistence;
using FoodTracker.Data.Domain.Application.User;
using System.Threading.Tasks;

namespace FoodTracker.Application.User;

internal class SettingsService : ISettings
{
    private ISettingsRepository _repository;

    public SettingsService(ISettingsRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateOrUpdate(int userId, double energy, double protein, double fat, double carb)
    {
        await _repository.CreateOrUpdate(userId, energy, protein, fat, carb);
    }

    public async Task<IUserSettings> GetForUserAsync(int id)
    {
        var dbSettings = await _repository.GetSettingsForUser(id);
        if (dbSettings is null)
            return new UserSettings();
        return dbSettings.ToDomainModel();
    }
}