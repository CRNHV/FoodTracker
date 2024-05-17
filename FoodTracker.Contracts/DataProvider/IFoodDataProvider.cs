using FoodTracker.Data.Domain.DataProvider;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodTracker.Contracts.DataProvider;

public interface IFoodDataProvider
{
    Task<IBaseProductData?> SearchBaseProductByIdAsync(string productId);

    Task<IProductInfoData?> SearchByEanAsync(string ean);

    Task<IProductInfoData?> SearchByProductIdAsync(string productId);

    Task<IReadOnlyCollection<IProductSearchResultData>> SearchByNameAsync(string productname);
}