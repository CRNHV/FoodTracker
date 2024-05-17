using FoodTracker.Contracts.Application.Products;
using FoodTracker.Contracts.DataProvider;
using FoodTracker.Contracts.Persistence;
using FoodTracker.Data.Domain.DataProvider;
using FoodTracker.Data.Domain.Persistence.Product;
using FoodTracker.Data.Persistence.Entities.Product;
using FoodTracker.Data.Persistence.Mappings;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTracker.Data.Persistence;

internal sealed class ProductUpdater : IDataUpdater
{
    private readonly IFoodDataProvider _dataProvider;
    private readonly IProductRepository _persistence;

    public ProductUpdater(IFoodDataProvider dataProvider, IProductRepository persistence)
    {
        _dataProvider = dataProvider;
        _persistence = persistence;
    }

    public async Task<IBaseProductEntity?> UpdateBaseProductByProductIdAsync(string productId)
    {
        IBaseProductData? foodInApi = await _dataProvider.SearchBaseProductByIdAsync(productId);
        if (foodInApi is null)
            return null;
        var dbEntity = foodInApi.ToEntity();

        foreach (var item in dbEntity.Products)
        {
            ((ProductEntity)item).ProductInfoId = item.ProductInfo.Id;
            ((ProductInfoEntity)item.ProductInfo).ProductInfoId = item.ProductInfo.Id;
        }

        await _persistence.InsertOrUpdateAsync(dbEntity);
        return dbEntity;
    }

    public async Task<IProductEntity?> UpdateProductByEanAsync(string ean)
    {
        IProductInfoData? productInApi = await _dataProvider.SearchByEanAsync(ean);
        if (productInApi is null)
            return null;

        var productEntity = productInApi.ProductData.ToEntity();

        await _persistence.InsertAsync(productEntity);

        return productEntity;
    }

    public async Task<IProductEntity?> UpdateProductByIdAsync(string productId)
    {
        IProductInfoData? productInApi = await _dataProvider.SearchByProductIdAsync(productId);
        if (productInApi is null)
            return null;

        var dbUnits = await _persistence.GetExistingUnitsAsync();
        var filteredProductDataUnits = productInApi.ProductData.Units.ToList();

        foreach (var unit in productInApi.ProductData.Units)
        {
            bool idAlreadyInDb = dbUnits.Any(x => x.Id == unit.Id);
            if (idAlreadyInDb)
            {
            }
            else if (dbUnits.Any(c => c.UnitName == unit.UnitName && c.DisplayName == unit.DisplayName && c.GramsPerUnit == unit.GramsPerUnit))
            {
                filteredProductDataUnits.Remove(unit);
            }
        }

        productInApi.ProductData.Units = filteredProductDataUnits;

        var productEntity = productInApi.ProductData.ToEntity();
        productEntity.ProductName = productInApi.ProductName;
        productEntity.BrandName = productInApi.BrandName;
        productEntity.ProductId = productInApi.Id;
        productEntity.Ean = productInApi.Ean;

        await _persistence.InsertAsync(productEntity);

        return productEntity;
    }
}