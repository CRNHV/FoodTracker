using FoodTracker.Data.Domain.Persistence.Product;
using System;
using System.ComponentModel.DataAnnotations;

namespace FoodTracker.Data.Persistence.Entities.Product;

public sealed class MeasurementUnitEntity : IMeasurementUnitEntity
{
    [Key]
    public string? Id { get; set; }

    public string? DisplayName { get; set; }
    public string? UnitName { get; set; }
    public double? GramsPerUnit { get; set; }
    public bool IsTussendoortje { get; set; }

    public DateTime CreatedOnUtc { get; set; }
    public DateTime LastUpdatedOnUtc { get; set; }
}