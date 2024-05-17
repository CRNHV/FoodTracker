namespace FoodTracker.Data.Domain.Persistence.Product;

public interface ISearchResultEntity
{
    string BrandName { get; set; }
    string Id { get; set; }
    string ProductName { get; set; }
    int Type { get; set; }
}