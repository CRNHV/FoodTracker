using FoodTracker.Data.Domain.Persistence.Product;
using FoodTracker.Data.Domain.Persistence.ProductTracking;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTracker.Data.Persistence.Entities.ProductTracking;

internal class TrackedMealEntity : ITrackedMealEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int UserId { get; set; }
    public int Quantity { get; set; }
    public IMeasurementUnitEntity Unit { get; set; }
    public IProductEntity Product { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime LastUpdatedOnUtc { get; set; }

    [ForeignKey("Product")]
    public string? ProductId { get; set; }

    [ForeignKey("Unit")]
    public string? MeasurementUnitId { get; set; }
}