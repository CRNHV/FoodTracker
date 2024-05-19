using FoodTracker.Data.Domain.DataProvider;
using System.Text.Json.Serialization;

namespace FoodTracker.Provider.VoedingCentrum.Models;

internal sealed class PreparationMethodData : IPreparationMethodData
{
    [JsonPropertyName("Id")]
    public string? Id { get; set; }

    [JsonPropertyName("Name")]
    public string? Name { get; set; }

    [JsonPropertyName("IsRaw")]
    public bool IsRaw { get; set; }
}