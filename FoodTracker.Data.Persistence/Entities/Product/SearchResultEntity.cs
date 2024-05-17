using FoodTracker.Data.Domain.Persistence.Product;

namespace FoodTracker.Data.Persistence.Entities.Product;

internal sealed class SearchResultEntity : ISearchResultEntity
{
    public string BrandName { get; set; }
    public string Id { get; set; }
    public string ProductName { get; set; }
    public int Type { get; set; }
    public object Key { get; set; }
}