namespace FoodTracker.Data.Domain.Persistence.Product;

public interface IMeasurementUnitEntity : IEntityBase
{
    string? Id { get; set; }
    string? DisplayName { get; set; }
    string? UnitName { get; set; }
    double? GramsPerUnit { get; set; }
    bool IsTussendoortje { get; set; }
}