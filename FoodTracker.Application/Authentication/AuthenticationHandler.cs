using FoodTracker.Contracts.Application.Authentication;
using FoodTracker.Data.Domain.Application.Authentication;
using System.Threading.Tasks;

namespace FoodTracker.Application.Authentication;

internal sealed class AuthenticationHandler : IUserAuthentication
{
    public AuthenticationHandler()
    {
    }

    public async Task<IUser?> LoginAsync(string username, string password)
    {
        //var userWithUsername = await _users.GetByName(username);
        //if (userWithUsername is null)
        //    return null;

        //if (userWithUsername.Password != password)
        //    return null;

        return new User()
        {
            //Id = userWithUsername.Id,
            //LastLogin = userWithUsername.LastUpdatedOnUtc,
            //Username = userWithUsername.Username,
        };
    }

    public async Task<IUser?> RegisterAsync(string username, string password)
    {
        //var userWithUsername = await _users.GetByName(username);
        //if (userWithUsername is null)
        //    return null;

        //var dbRegisteredEntity = await _users.CreateNewAsync(username, password);
        //if (dbRegisteredEntity is null)
        //    return null;

        return new User()
        {
            //Id = dbRegisteredEntity.Id,
            //Username = dbRegisteredEntity.Username,
            //LastLogin = dbRegisteredEntity.LastUpdatedOnUtc,
        };
    }
}