using FoodTracker.Data.Domain.DataProvider;
using FoodTracker.Data.Domain.Persistence.Product;
using FoodTracker.Data.Persistence.Entities.Product;
using System;
using System.Linq;

namespace FoodTracker.Data.Persistence.Mappings;

public static class BaseProductMappings
{
    public static IBaseProductEntity ToEntity(this IBaseProductData data)
    {
        return new BaseProductEntity()
        {
            BaseProductId = data.Id,
            Name = data.Name,
            CreatedOnUtc = DateTime.UtcNow,
            LastUpdatedOnUtc = DateTime.UtcNow,
            Products = data.Products.Select(x => x.ToEntity()).ToList(),
        };
    }

    public static IProductEntity ToEntity(this IProductData data)
    {
        return new ProductEntity()
        {
            ProductId = data.Id,
            BaseProductId = data.BaseProductId,
            BaseProductName = data.BaseProductName,
            BrandName = data.BrandName,
            CreatedOnUtc = DateTime.UtcNow,
            LastUpdatedOnUtc = DateTime.UtcNow,
            ProductName = data.ProductName,
            Units = data.Units.Select(x => x.ToEntity()).ToList(),
            ProductInfo = BuildProductInfo(data),
        };
    }

    public static IMeasurementUnitEntity ToEntity(this IMeasurementUnitData data)
    {
        return new MeasurementUnitEntity()
        {
            DisplayName = data.DisplayName,
            GramsPerUnit = data.GramsPerUnit,
            Id = data.Id,
            IsTussendoortje = data.IsTussendoortje,
            UnitName = data.UnitName,
            CreatedOnUtc = DateTime.UtcNow,
            LastUpdatedOnUtc = DateTime.UtcNow,
        };
    }

    public static IProductInfoEntity ToEntity(this IProductInfoData data)
    {
        return new ProductInfoEntity()
        {
            Alcohol = data.Alcohol,
            Calcium = data.Calcium,
            Eiwit = data.Eiwit,
            EiwitPlantaardig = data.EiwitPlantaardig,
            Energie = data.Energie,
            Foliumzuur = data.Foliumzuur,
            Fosfor = data.Fosfor,
            Id = data.Id,
            IJzer = data.IJzer,
            Jodium = data.Jodium,
            Kalium = data.Kalium,
            Koolhydraten = data.Koolhydraten,
            Magnesium = data.Magnesium,
            Natrium = data.Natrium,
            Nicotinezuur = data.Nicotinezuur,
            Selenium = data.Selenium,
            Suikers = data.Suikers,
            VerzadigdVet = data.VerzadigdVet,
            Vezels = data.Vezels,
            Vet = data.Vet,
            VitamineA = data.VitamineA,
            VitamineB1 = data.VitamineB1,
            VitamineB12 = data.VitamineB12,
            VitamineB2 = data.VitamineB2,
            VitamineB6 = data.VitamineB6,
            VitamineC = data.VitamineC,
            Zout = data.Zout,
            VitamineD = data.VitamineD,
            VitamineE = data.VitamineE,
            Water = data.Water,
            Zink = data.Zink,
            WeightGainFactor = data.WeightGainFactor,
            ProductGroupId = data.ProductGroupId,
            IsObsolete = data.IsObsolete,
            Ean = data.Ean,
            NutritionalValuesBasedOnPreparedProduct = data.NutritionalValuesBasedOnPreparedProduct,
        };
    }

    public static IProductInfoEntity BuildProductInfo(IProductData data)
    {
        return new ProductInfoEntity()
        {
            Alcohol = data.Alcohol,
            Calcium = data.Calcium,
            Eiwit = data.Eiwit,
            EiwitPlantaardig = data.EiwitPlantaardig,
            Energie = data.Energie,
            Foliumzuur = data.Foliumzuur,
            Fosfor = data.Fosfor,
            Id = data.Id,
            IJzer = data.IJzer,
            Jodium = data.Jodium,
            Kalium = data.Kalium,
            Koolhydraten = data.Koolhydraten,
            Magnesium = data.Magnesium,
            Natrium = data.Natrium,
            Nicotinezuur = data.Nicotinezuur,
            Selenium = data.Selenium,
            Suikers = data.Suikers,
            VerzadigdVet = data.VerzadigdVet,
            Vezels = data.Vezels,
            Vet = data.Vet,
            VitamineA = data.VitamineA,
            VitamineB1 = data.VitamineB1,
            VitamineB12 = data.VitamineB12,
            VitamineB2 = data.VitamineB2,
            VitamineB6 = data.VitamineB6,
            VitamineC = data.VitamineC,
            Zout = data.Zout,
            VitamineD = data.VitamineD,
            VitamineE = data.VitamineE,
            Water = data.Water,
            Zink = data.Zink,
            WeightGainFactor = data.WeightGainFactor,
            ProductGroupId = data.ProductGroupId,
            IsObsolete = data.IsObsolete,
        };
    }
}