namespace FoodTracker.Data.Domain.Application.Product;

public interface IPreperationMethod
{
    string? Id { get; set; }
    bool IsRaw { get; set; }
    string? Name { get; set; }
}