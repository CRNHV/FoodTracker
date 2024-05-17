using FoodTracker.Data.Domain.Application.Authentication;
using System.Threading.Tasks;

namespace FoodTracker.Contracts.Application.Authentication;

public interface IUserAuthentication
{
    Task<IUser?> LoginAsync(string username, string password);

    Task<IUser?> RegisterAsync(string username, string password);
}