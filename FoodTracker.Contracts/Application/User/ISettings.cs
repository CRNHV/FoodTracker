using FoodTracker.Data.Domain.Application.User;
using System.Threading.Tasks;

namespace FoodTracker.Contracts.Application.User;

public interface ISettings
{
    Task<IUserSettings> GetForUserAsync(int id);

    Task CreateOrUpdate(int userId, double energy, double protein, double fat, double carb);
}