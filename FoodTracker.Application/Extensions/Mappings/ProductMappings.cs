using FoodTracker.Application.TrackedMeals.Products.Models;
using FoodTracker.Data.Domain.Application.Product;
using FoodTracker.Data.Domain.Persistence.Product;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FoodTracker.Application.Extensions.Mappings;

internal static class ProductMappings
{
    public static IBaseProduct EntityToDomainModel(this IBaseProductEntity data)
    {
        return new BaseProduct()
        {
            Id = data.BaseProductId,
            Name = data.Name,
            Products = data.Products != null && data.Products.Count > 0
                ? data.Products.Select(x => x.EntityToDomainModel()).ToList() : new List<IProduct>(),
        };
    }

    public static IProduct EntityToDomainModel(this IProductEntity data)
    {
        return new Product()
        {
            Ean = data.Ean,
            BaseProductId = data.BaseProductId,
            BaseProductName = data.BaseProductName,
            BrandName = data.BrandName,
            Id = data.ProductInfo?.Id ?? data.ProductId,
            Units = data.Units.Count >= 1 ? data.Units.Select(x => x.EntityToDomainModel()).ToList() : new List<IMeasurementUnit>(),
            ProductName = data.ProductName,
            ProductInfo = data.ProductInfo != null ? data.ProductInfo.EntityToDomainModel() : null,
        };
    }

    public static IMeasurementUnit EntityToDomainModel(this IMeasurementUnitEntity data)
    {
        return new MeasurementUnit()
        {
            DisplayName = data.DisplayName,
            GramsPerUnit = data.GramsPerUnit,
            IsTussendoortje = data.IsTussendoortje,
            UnitName = data.UnitName,
        };
    }

    public static ISearchResult EntityToDomainModel(this ISearchResultEntity data)
    {
        return new SearchResult()
        {
            BrandName = data.BrandName,
            Id = data.Id,
            ProductName = data.ProductName,
        };
    }

    public static IProductInfo EntityToDomainModel(this IProductInfoEntity data)
    {
        return new ProductInfo()
        {
            Eiwit = data.Eiwit,
            EiwitPlantaardig = data.EiwitPlantaardig,
            Energie = data.Energie,
            Koolhydraten = data.Koolhydraten,
            Suikers = data.Suikers,
            VerzadigdVet = data.VerzadigdVet,
            Vet = data.Vet,
            Vezels = data.Vezels,
        };
    }
}