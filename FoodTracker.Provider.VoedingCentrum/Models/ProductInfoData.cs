using FoodTracker.Data.Domain.DataProvider;
using System.Text.Json.Serialization;

namespace FoodTracker.Provider.VoedingCentrum.Models;

internal sealed class ProductInfoData : IProductInfoData
{
    [JsonPropertyName("ProductId")]
    public string? ProductId { get; set; }

    [JsonPropertyName("Ean")]
    public string? Ean { get; set; }

    [JsonIgnore]
    public IProductData ProductData
    { get => ProductImpl; set { ProductImpl = (ProductData)value; } }

    [JsonPropertyName("Product")]
    public ProductData ProductImpl { get; set; }

    [JsonPropertyName("NutritionalValuesBasedOnPreparedProduct")]
    public bool NutritionalValuesBasedOnPreparedProduct { get; set; }

    [JsonPropertyName("Alcohol")]
    public double? Alcohol { get; set; }

    [JsonPropertyName("BrandName")]
    public string? BrandName { get; set; }

    [JsonPropertyName("Calcium")]
    public double? Calcium { get; set; }

    [JsonPropertyName("Eiwit")]
    public double? Eiwit { get; set; }

    [JsonPropertyName("EiwitPlantaardig")]
    public double? EiwitPlantaardig { get; set; }

    [JsonPropertyName("Energie")]
    public double? Energie { get; set; }

    [JsonPropertyName("Foliumzuur")]
    public double? Foliumzuur { get; set; }

    [JsonPropertyName("Fosfor")]
    public double? Fosfor { get; set; }

    [JsonPropertyName("Id")]
    public string? Id { get; set; }

    [JsonPropertyName("IJzer")]
    public double? IJzer { get; set; }

    [JsonPropertyName("IsObsolete")]
    public bool IsObsolete { get; set; }

    [JsonPropertyName("Jodium")]
    public double? Jodium { get; set; }

    [JsonPropertyName("Kalium")]
    public double? Kalium { get; set; }

    [JsonPropertyName("Koolhydraten")]
    public double? Koolhydraten { get; set; }

    [JsonPropertyName("Magnesium")]
    public double? Magnesium { get; set; }

    [JsonPropertyName("Natrium")]
    public double? Natrium { get; set; }

    [JsonPropertyName("Nicotinezuur")]
    public double? Nicotinezuur { get; set; }

    [JsonPropertyName("ProductGroupId")]
    public string? ProductGroupId { get; set; }

    [JsonPropertyName("ProductName")]
    public string? ProductName { get; set; }

    [JsonPropertyName("Selenium")]
    public double? Selenium { get; set; }

    [JsonPropertyName("Suikers")]
    public double? Suikers { get; set; }

    [JsonPropertyName("VerzadigdVet")]
    public double? VerzadigdVet { get; set; }

    [JsonPropertyName("Vet")]
    public double? Vet { get; set; }

    [JsonPropertyName("Vezels")]
    public double? Vezels { get; set; }

    [JsonPropertyName("VitamineA")]
    public double? VitamineA { get; set; }

    [JsonPropertyName("VitamineB1")]
    public double? VitamineB1 { get; set; }

    [JsonPropertyName("VitamineB12")]
    public double? VitamineB12 { get; set; }

    [JsonPropertyName("VitamineB2")]
    public double? VitamineB2 { get; set; }

    [JsonPropertyName("VitamineB6")]
    public double? VitamineB6 { get; set; }

    [JsonPropertyName("VitamineC")]
    public double? VitamineC { get; set; }

    [JsonPropertyName("VitamineD")]
    public double? VitamineD { get; set; }

    [JsonPropertyName("VitamineE")]
    public double? VitamineE { get; set; }

    [JsonPropertyName("Water")]
    public double? Water { get; set; }

    [JsonPropertyName("WeightGainFactor")]
    public double? WeightGainFactor { get; set; }

    [JsonPropertyName("Zink")]
    public double? Zink { get; set; }

    [JsonPropertyName("Zout")]
    public double? Zout { get; set; }
}