using FoodTracker.Data.Domain.Application.User;
using FoodTracker.Web.UI.Models;
using FoodTracker.Web.UI.Models.Settings;

namespace FoodTracker.Web.UI.Services.Settings;

public interface ISettingsService
{
    Task<Result<IUserSettings>> GetForUserAsync();

    Task<Result<IUserSettings>> CreateOrUpdateAsync(UserSettingsModel settings);
}