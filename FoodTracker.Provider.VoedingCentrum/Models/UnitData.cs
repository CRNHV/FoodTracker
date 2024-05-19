using FoodTracker.Data.Domain.DataProvider;
using System.Text.Json.Serialization;

namespace FoodTracker.Provider.VoedingCentrum.Models;

internal sealed class UnitData : IMeasurementUnitData
{
    [JsonPropertyName("DisplayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("GramsPerUnit")]
    public double? GramsPerUnit { get; set; }

    [JsonPropertyName("Id")]
    public string? Id { get; set; }

    [JsonPropertyName("IsObsolete")]
    public bool IsObsolete { get; set; }

    [JsonPropertyName("IsTussendoortje")]
    public bool IsTussendoortje { get; set; }

    [JsonPropertyName("ProductId")]
    public string? ProductId { get; set; }

    [JsonPropertyName("ProductName")]
    public string? ProductName { get; set; }

    [JsonPropertyName("UnitId")]
    public string? UnitId { get; set; }

    [JsonPropertyName("UnitName")]
    public string? UnitName { get; set; }
}