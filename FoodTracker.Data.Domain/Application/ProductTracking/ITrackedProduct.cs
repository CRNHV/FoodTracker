using FoodTracker.Data.Domain.Application.Product;
using System;

namespace FoodTracker.Data.Domain.Application.ProductTracking;

public interface ITrackedProduct
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int Quantity { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public IMeasurementUnit? Unit { get; set; }
    public IProduct? Product { get; set; }
}