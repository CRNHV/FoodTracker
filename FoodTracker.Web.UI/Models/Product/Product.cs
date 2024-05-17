using FoodTracker.Data.Domain.Application.Product;
using System.Text.Json.Serialization;

namespace FoodTracker.Web.UI.Models.Product;

public class Product : IProduct
{
    public string? BaseProductId { get; set; }
    public string? BaseProductName { get; set; }
    public string? Id { get; set; }
    public string? ProductName { get; set; }
    public string? Ean { get; set; }
    public string? BrandName { get; set; }

    [JsonPropertyName("Units")]
    public IReadOnlyCollection<MeasurementUnit> UnitsImpl { get; set; }

    [JsonIgnore]
    public IReadOnlyCollection<IMeasurementUnit> Units { get => UnitsImpl; set => UnitsImpl = (IReadOnlyCollection<MeasurementUnit>)value; }

    [JsonPropertyName("ProductInfo")]
    public ProductInfo? ProductInfoImpl { get; set; }

    [JsonIgnore]
    public IProductInfo? ProductInfo { get => ProductInfoImpl; set => ProductInfoImpl = (ProductInfo?)value; }
}