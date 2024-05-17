namespace FoodTracker.Data.Domain.DataProvider;

public interface IProductSearchResultData
{
    public string BrandName { get; set; }
    public string Id { get; set; }
    public string ProductName { get; set; }
    public int Type { get; set; }
    public object SynonymId { get; set; }
    public object Key { get; set; }
}