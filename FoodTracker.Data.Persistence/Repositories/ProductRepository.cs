using FoodTracker.Contracts.DataProvider;
using FoodTracker.Contracts.Persistence;
using FoodTracker.Data.Domain.Persistence.Product;
using FoodTracker.Data.Persistence.Context;
using FoodTracker.Data.Persistence.Entities.Product;
using FoodTracker.Data.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTracker.Data.Persistence.Repositories;

internal sealed class ProductRepository : IProductRepository
{
    private readonly VoedingDbContext _context;
    private readonly IFoodDataProvider _foodDataApi;

    public ProductRepository(VoedingDbContext context, IFoodDataProvider foodDataApi)
    {
        _context = context;
        _foodDataApi = foodDataApi;
    }

    public async Task<IBaseProductEntity?> GetBaseProductByIdAsync(string baseProductId)
    {
        return await _context.BaseProducts
            .FirstOrDefaultAsync(product => product.BaseProductId == baseProductId);
    }

    public async Task<IProductEntity?> GetByEanAsync(string ean)
    {
        return await _context.Products
            .FirstOrDefaultAsync(product => product.Ean == ean);
    }

    public async Task<IProductEntity?> GetByIdAsync(string productId)
    {
        return await _context.Products
            .Include(product => product.ProductInfo)
            .Include(product => product.Units)
            .FirstOrDefaultAsync(product => product.ProductId == productId);
    }

    public async Task InsertOrUpdateAsync(IBaseProductEntity dbEntity)
    {
        var baseProduct = await _context.BaseProducts
            .FirstOrDefaultAsync(product => product.BaseProductId.Equals(dbEntity.BaseProductId));

        if (baseProduct is null)
        {
            baseProduct = dbEntity as BaseProductEntity;
            await _context.BaseProducts.AddAsync(baseProduct);
            await _context.SaveChangesAsync();
        }
    }

    public async Task InsertAsync(IProductEntity productEntity)
    {
        var dbProduct = await _context.Products
            .FirstOrDefaultAsync(product => product.ProductId.Equals(productEntity.ProductId));

        if (dbProduct is null)
        {
            dbProduct = productEntity as ProductEntity;
            dbProduct.ProductInfo.Id = productEntity.ProductId;
            dbProduct.ProductInfoId = productEntity.ProductInfo.Id;
            ((ProductInfoEntity)dbProduct.ProductInfo).ProductInfoId = productEntity.ProductInfo.Id;
            await _context.Products.AddAsync(dbProduct);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IReadOnlyCollection<ISearchResultEntity>> SearchByNameAsync(string name)
    {
        var searchResults = await _foodDataApi.SearchByNameAsync(name);
        return searchResults.Select(x => x.ToEntity()).ToList();
    }

    public async Task<IEnumerable<IMeasurementUnitEntity>> GetExistingUnitsAsync()
    {
        return await _context.MeasurementUnits.Select(x => new MeasurementUnitEntity
        {
            DisplayName = x.DisplayName,
            GramsPerUnit = x.GramsPerUnit,
            UnitName = x.UnitName,
        }).ToArrayAsync();
    }
}