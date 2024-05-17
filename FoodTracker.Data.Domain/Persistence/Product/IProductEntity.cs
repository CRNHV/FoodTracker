using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodTracker.Data.Domain.Persistence.Product;

public interface IProductEntity : IEntityBase
{
    [Key]
    public string? ProductId { get; set; }

    public string? Ean { get; set; }
    string? BaseProductId { get; set; }
    string? BaseProductName { get; set; }
    string? BrandName { get; set; }
    string? ProductName { get; set; }

    public IProductInfoEntity ProductInfo { get; set; }
    public ICollection<IMeasurementUnitEntity> Units { get; set; }
}