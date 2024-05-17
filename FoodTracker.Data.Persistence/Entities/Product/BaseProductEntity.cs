using FoodTracker.Data.Domain.Persistence.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodTracker.Data.Persistence.Entities.Product;

internal sealed class BaseProductEntity : IBaseProductEntity
{
    [Key]
    public string BaseProductId { get; set; }

    public string Name { get; set; }

    public DateTime CreatedOnUtc { get; set; }
    public DateTime LastUpdatedOnUtc { get; set; }

    public ICollection<IProductEntity> Products { get; set; }
}