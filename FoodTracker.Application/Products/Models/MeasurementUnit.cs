using FoodTracker.Data.Domain.Application.Product;

namespace FoodTracker.Application.Products.Models;

internal class MeasurementUnit : IMeasurementUnit
{
    public string? DisplayName { get; set; }

    public double? GramsPerUnit { get; set; }

    public bool IsTussendoortje { get; set; }

    public string? UnitName { get; set; }
}