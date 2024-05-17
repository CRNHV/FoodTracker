using FoodTracker.Data.Domain.Persistence.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodTracker.Data.Persistence.Entities.Product;

internal sealed class ProductEntity : IProductEntity
{
    [Key]
    public string? ProductId { get; set; }

    public string? Ean { get; set; }
    public string? BaseProductId { get; set; }
    public string? BaseProductName { get; set; }
    public string? BrandName { get; set; }
    public string? ProductName { get; set; }

    public DateTime CreatedOnUtc { get; set; }
    public DateTime LastUpdatedOnUtc { get; set; }

    public string ProductInfoId { get; set; }
    public IProductInfoEntity ProductInfo { get; set; }

    public ICollection<IMeasurementUnitEntity> Units { get; set; } = [];
}