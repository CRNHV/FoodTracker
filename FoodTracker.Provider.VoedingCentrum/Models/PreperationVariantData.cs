using FoodTracker.Data.Domain.DataProvider;
using System.Text.Json.Serialization;

namespace FoodTracker.Provider.VoedingCentrum.Models;

internal sealed class PreparationVariantData : IPreparationVariantData
{
    [JsonPropertyName("Id")]
    public string? Id { get; set; }

    [JsonPropertyName("Name")]
    public string? Name { get; set; }

    [JsonIgnore]
    public IProductData Product { get => ProductImpl; set => ProductImpl = (ProductData)value; }

    [JsonPropertyName("Product")]
    public ProductData ProductImpl { get; set; }

    [JsonPropertyName("SortOrder")]
    public int SortOrder { get; set; }

    [JsonPropertyName("ProductId")]
    public string? ProductId { get; set; }
}