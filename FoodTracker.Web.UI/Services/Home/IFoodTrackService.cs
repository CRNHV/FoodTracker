using FoodTracker.Data.Domain.Application.Product;
using FoodTracker.Web.UI.Models;

namespace FoodTracker.Web.UI.Services.Home;

public interface IFoodTrackService
{
    Task<Result<IReadOnlyCollection<ISearchResult>>> SearchByNameAsync(string name);

    Task<Result<IProduct>> SearchByEanAsync(string ean);

    Task<Result<IProduct>> SearchByIdAsync(string id);

    Task<bool> AddFoodToEatListAsync(IProduct productInfo);

    Task<bool> RemoveFoodFromEatListAsync(IProduct productInfo);
}