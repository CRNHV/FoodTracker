namespace FoodTracker.Data.Domain.Application.Product;

public interface ISearchResult
{
    string BrandName { get; set; }
    string Id { get; set; }
    string ProductName { get; set; }
}