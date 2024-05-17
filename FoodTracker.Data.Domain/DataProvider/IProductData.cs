using System.Collections.Generic;

namespace FoodTracker.Data.Domain.DataProvider;

public interface IProductData
{
    public string? ProductId { get; set; }
    public string? BaseProductId { get; set; }

    public string? BaseProductName { get; set; }

    public int ConsumptionInputTipType { get; set; }

    public double? Alcohol { get; set; }

    public string? BrandName { get; set; }

    public double? Calcium { get; set; }

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

    public string? ProductGroupId { get; set; }

    public string? ProductName { get; set; }

    public object PreparedToRawCorrectionFactor { get; set; }

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

    public IPreparationMethodData PreparationMethod { get; set; }
    public IReadOnlyCollection<IBaseProductSynonymData> BaseProductSynonyms { get; set; }
    public IReadOnlyCollection<IPreparationVariantData> PreparationVariants { get; set; }
    public List<IMeasurementUnitData> Units { get; set; }
}