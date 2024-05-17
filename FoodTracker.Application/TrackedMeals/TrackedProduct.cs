using FoodTracker.Data.Domain.Application.Product;
using FoodTracker.Data.Domain.Application.ProductTracking;
using System;

namespace FoodTracker.Application.TrackedMeals;

internal class TrackedProduct : ITrackedProduct
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int Quantity { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public IMeasurementUnit? Unit { get; set; }
    public IProduct? Product { get; set; }
}