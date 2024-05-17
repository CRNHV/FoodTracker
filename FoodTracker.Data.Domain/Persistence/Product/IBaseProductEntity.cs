using System.Collections.Generic;

namespace FoodTracker.Data.Domain.Persistence.Product;

public interface IBaseProductEntity : IEntityBase
{
    string BaseProductId { get; set; }
    string Name { get; set; }
    ICollection<IProductEntity> Products { get; set; }
}