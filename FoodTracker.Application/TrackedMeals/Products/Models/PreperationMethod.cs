using FoodTracker.Data.Domain.Application.Product;

namespace FoodTracker.Application.TrackedMeals.Products.Models;

internal sealed class PreperationMethod : IPreperationMethod
{
    public string? Id { get; set; }
    public bool IsRaw { get; set; }
    public string? Name { get; set; }
}