namespace FoodTracker.Data.Domain.DataProvider;

public interface IPreparationMethodData
{
    string? Id { get; set; }
    bool IsRaw { get; set; }
    string? Name { get; set; }
}