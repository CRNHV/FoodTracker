using FoodTracker.Data.Domain.DataProvider;
using FoodTracker.Data.Domain.Persistence.Product;
using FoodTracker.Data.Persistence.Entities.Product;

namespace FoodTracker.Data.Persistence.Mappings;

internal static class SearchResultMapping
{
    public static ISearchResultEntity ToEntity(this IProductSearchResultData data)
    {
        return new SearchResultEntity()
        {
            Id = data.Id,
            BrandName = data.BrandName,
            Key = data.Key,
            ProductName = data.ProductName,
            Type = data.Type
        };
    }
}