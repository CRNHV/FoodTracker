using FoodTracker.Data.Domain.DataProvider;
using System.Text.Json.Serialization;

namespace FoodTracker.Provider.VoedingCentrum.Models;

internal sealed class BaseProductSynonymData : IBaseProductSynonymData
{
    [JsonPropertyName("Id")]
    public string? Id { get; set; }

    [JsonPropertyName("Name")]
    public string? Name { get; set; }
}