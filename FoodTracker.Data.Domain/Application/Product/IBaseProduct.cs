using System.Collections.Generic;

namespace FoodTracker.Data.Domain.Application.Product;

public interface IBaseProduct
{
    string Id { get; set; }
    string Name { get; set; }
    IReadOnlyCollection<IProduct> Products { get; set; }
}