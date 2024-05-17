using FoodTracker.Data.Domain.Application.Product;
using FoodTracker.Data.Domain.Application.ProductTracking;
using System.Text.Json.Serialization;

namespace FoodTracker.Web.UI.Models.Product;

public class TrackedProductModel : ITrackedProduct
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int Quantity { get; set; }
    public DateTime CreatedOnUtc { get; set; }

    [JsonPropertyName("Unit")]
    public MeasurementUnit UnitImpl { get; set; }

    [JsonPropertyName("Product")]
    public Product ProductImpl { get; set; }

    [JsonIgnore]
    public IMeasurementUnit? Unit { get => UnitImpl; set => UnitImpl = (MeasurementUnit)value; }

    [JsonIgnore]
    public IProduct? Product { get => ProductImpl; set => ProductImpl = (Product)value; }
}