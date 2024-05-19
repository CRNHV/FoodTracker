using FoodTracker.Data.Domain.DataProvider;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FoodTracker.Provider.VoedingCentrum.Models;

internal sealed class BaseProductData : IBaseProductData
{
    [JsonPropertyName("Name")]
    public string Name { get; set; }

    [JsonPropertyName("Id")]
    public string Id { get; set; }

    [JsonPropertyName("Synonyms")]
    public IReadOnlyCollection<object> Synonyms { get; set; }

    [JsonPropertyName("Products")]
    public IReadOnlyCollection<ProductData> ProductsImpl { get; set; }

    [JsonIgnore]
    public IReadOnlyCollection<IProductData> Products { get => ProductsImpl; set => ProductsImpl = (IReadOnlyCollection<ProductData>)value; }
}