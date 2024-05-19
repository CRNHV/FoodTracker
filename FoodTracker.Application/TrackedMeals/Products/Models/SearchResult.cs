using FoodTracker.Data.Domain.Application.Product;

namespace FoodTracker.Application.TrackedMeals.Products.Models;

internal sealed class SearchResult : ISearchResult
{
    public string BrandName { get; set; }
    public string Id { get; set; }
    public string ProductName { get; set; }
}