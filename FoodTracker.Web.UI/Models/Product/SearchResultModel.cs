using FoodTracker.Data.Domain.Application.Product;

namespace FoodTracker.Web.UI.Models.Product;

internal sealed class SearchResultModel : ISearchResult
{
    public string BrandName { get; set; }
    public string Id { get; set; }
    public string ProductName { get; set; }
}