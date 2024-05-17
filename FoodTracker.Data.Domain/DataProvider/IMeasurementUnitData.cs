namespace FoodTracker.Data.Domain.DataProvider;

public interface IMeasurementUnitData
{
    public string? DisplayName { get; set; }

    public double? GramsPerUnit { get; set; }

    public string? Id { get; set; }

    public bool IsObsolete { get; set; }

    public bool IsTussendoortje { get; set; }

    public string? ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? UnitId { get; set; }

    public string? UnitName { get; set; }
}