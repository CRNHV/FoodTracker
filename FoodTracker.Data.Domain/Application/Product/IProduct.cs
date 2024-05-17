using System.Collections.Generic;

namespace FoodTracker.Data.Domain.Application.Product;

public interface IProduct
{
    public string? BaseProductId { get; set; }
    public string? BaseProductName { get; set; }
    public string? Id { get; set; }
    public string? ProductName { get; set; }
    public string? Ean { get; set; }
    public string? BrandName { get; set; }

    public IReadOnlyCollection<IMeasurementUnit> Units { get; set; }
    public IProductInfo? ProductInfo { get; set; }
}