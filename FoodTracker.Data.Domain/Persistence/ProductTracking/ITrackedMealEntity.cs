using FoodTracker.Data.Domain.Persistence.Product;

namespace FoodTracker.Data.Domain.Persistence.ProductTracking;

public interface ITrackedMealEntity : IEntityBase
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int Quantity { get; set; }
    public string? ProductId { get; set; }
    public string? MeasurementUnitId { get; set; }

    public IMeasurementUnitEntity Unit { get; set; }
    public IProductEntity Product { get; set; }
}