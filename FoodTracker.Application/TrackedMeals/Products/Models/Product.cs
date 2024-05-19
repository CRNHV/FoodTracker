using FoodTracker.Data.Domain.Application.Product;
using System.Collections.Generic;

namespace FoodTracker.Application.TrackedMeals.Products.Models;

internal sealed class Product : IProduct
{
    public string? BaseProductId { get; set; }
    public string? BaseProductName { get; set; }
    public string? Id { get; set; }
    public string? ProductName { get; set; }
    public string? Ean { get; set; }
    public string? BrandName { get; set; }

    public IReadOnlyCollection<IMeasurementUnit> Units { get; set; } = new List<IMeasurementUnit>();
    public IProductInfo? ProductInfo { get; set; }
}