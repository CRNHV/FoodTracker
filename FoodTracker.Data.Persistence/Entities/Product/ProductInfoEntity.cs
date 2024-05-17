using FoodTracker.Data.Domain.Persistence.Product;
using System.ComponentModel.DataAnnotations;

namespace FoodTracker.Data.Persistence.Entities.Product;

internal sealed class ProductInfoEntity : IProductInfoEntity
{
    [Key]
    public string ProductInfoId { get; set; }

    public double? Alcohol { get; set; }
    public double? Calcium { get; set; }
    public string? Ean { get; set; }
    public double? Eiwit { get; set; }
    public double? EiwitPlantaardig { get; set; }
    public double? Energie { get; set; }
    public double? Foliumzuur { get; set; }
    public double? Fosfor { get; set; }
    public string? Id { get; set; }
    public double? IJzer { get; set; }
    public bool IsObsolete { get; set; }
    public double? Jodium { get; set; }
    public double? Kalium { get; set; }
    public double? Koolhydraten { get; set; }
    public double? Magnesium { get; set; }
    public double? Natrium { get; set; }
    public double? Nicotinezuur { get; set; }
    public bool NutritionalValuesBasedOnPreparedProduct { get; set; }
    public string? ProductGroupId { get; set; }
    public double? Selenium { get; set; }
    public double? Suikers { get; set; }
    public double? VerzadigdVet { get; set; }
    public double? Vet { get; set; }
    public double? Vezels { get; set; }
    public double? VitamineA { get; set; }
    public double? VitamineB1 { get; set; }
    public double? VitamineB12 { get; set; }
    public double? VitamineB2 { get; set; }
    public double? VitamineB6 { get; set; }
    public double? VitamineC { get; set; }
    public double? VitamineD { get; set; }
    public double? VitamineE { get; set; }
    public double? Water { get; set; }
    public double? WeightGainFactor { get; set; }
    public double? Zink { get; set; }
    public double? Zout { get; set; }
}