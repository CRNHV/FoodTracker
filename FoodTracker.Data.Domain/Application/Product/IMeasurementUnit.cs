namespace FoodTracker.Data.Domain.Application.Product;

public interface IMeasurementUnit
{
    public string? DisplayName { get; set; }

    public double? GramsPerUnit { get; set; }

    public bool IsTussendoortje { get; set; }

    public string? UnitName { get; set; }
}