using FoodTracker.Data.Domain.DataProvider;

namespace FoodTracker.Provider.VoedingCentrum.Models;

internal sealed class SearchResultData : IProductSearchResultData
{
    public string BrandName { get; set; }
    public string Id { get; set; }
    public string ProductName { get; set; }
    public int Type { get; set; }
    public object SynonymId { get; set; }
    public object Key { get; set; }
}