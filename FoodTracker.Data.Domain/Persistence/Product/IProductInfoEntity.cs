namespace FoodTracker.Data.Domain.Persistence.Product;

public interface IProductInfoEntity
{
    double? Alcohol { get; set; }
    double? Calcium { get; set; }
    string? Ean { get; set; }
    double? Eiwit { get; set; }
    double? EiwitPlantaardig { get; set; }
    double? Energie { get; set; }
    double? Foliumzuur { get; set; }
    double? Fosfor { get; set; }
    string? Id { get; set; }
    double? IJzer { get; set; }
    bool IsObsolete { get; set; }
    double? Jodium { get; set; }
    double? Kalium { get; set; }
    double? Koolhydraten { get; set; }
    double? Magnesium { get; set; }
    double? Natrium { get; set; }
    double? Nicotinezuur { get; set; }
    bool NutritionalValuesBasedOnPreparedProduct { get; set; }
    string? ProductGroupId { get; set; }
    double? Selenium { get; set; }
    double? Suikers { get; set; }
    double? VerzadigdVet { get; set; }
    double? Vet { get; set; }
    double? Vezels { get; set; }
    double? VitamineA { get; set; }
    double? VitamineB1 { get; set; }
    double? VitamineB12 { get; set; }
    double? VitamineB2 { get; set; }
    double? VitamineB6 { get; set; }
    double? VitamineC { get; set; }
    double? VitamineD { get; set; }
    double? VitamineE { get; set; }
    double? Water { get; set; }
    double? WeightGainFactor { get; set; }
    double? Zink { get; set; }
    double? Zout { get; set; }
}