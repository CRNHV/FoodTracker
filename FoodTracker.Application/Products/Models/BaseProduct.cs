using FoodTracker.Data.Domain.Application.Product;
using System.Collections.Generic;

namespace FoodTracker.Application.Products.Models;

internal sealed class BaseProduct : IBaseProduct
{
    public string Id { get; set; }
    public string Name { get; set; }
    public IReadOnlyCollection<IProduct> Products { get; set; } = new List<IProduct>();
}