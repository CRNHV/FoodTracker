namespace FoodTracker.Data.Domain.DataProvider;

public interface IPreparationVariantData
{
    string? Id { get; set; }
    string? Name { get; set; }
    IProductData Product { get; set; }
    string? ProductId { get; set; }
    int SortOrder { get; set; }
}