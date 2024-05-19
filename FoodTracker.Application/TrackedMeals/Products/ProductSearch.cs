using FoodTracker.Application.Extensions.Mappings;
using FoodTracker.Contracts.Application.Products;
using FoodTracker.Contracts.Persistence;
using FoodTracker.Data.Domain.Application.Product;
using FoodTracker.Data.Domain.Persistence.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTracker.Application.TrackedMeals.Products;

internal sealed class ProductSearch : IProductSearch
{
    private readonly IProductRepository _repository;
    private readonly IDataUpdater _dataUpdater;

    public ProductSearch(IProductRepository persistence, IDataUpdater dataUpdater)
    {
        _repository = persistence;
        _dataUpdater = dataUpdater;
    }

    public async Task<IBaseProduct?> BaseProductByIdAsync(string productId)
    {
        IBaseProductEntity? dbBaseProduct = await _repository.GetBaseProductByIdAsync(productId);
        if (dbBaseProduct == null || dbBaseProduct.LastUpdatedOnUtc <= DateTime.UtcNow.AddDays(-7))
        {
            dbBaseProduct = await _dataUpdater.UpdateBaseProductByProductIdAsync(productId);
        }

        return dbBaseProduct?.EntityToDomainModel();
    }

    public async Task<IProduct?> ByEanAsync(string ean)
    {
        IProductEntity? dbProduct = await _repository.GetByEanAsync(ean);
        if (dbProduct == null || dbProduct.LastUpdatedOnUtc < DateTime.UtcNow.AddDays(-7))
        {
            dbProduct = await _dataUpdater.UpdateProductByEanAsync(ean);
        }

        return dbProduct?.EntityToDomainModel();
    }

    public async Task<IProduct?> ByIdAsync(string productId)
    {
        IProductEntity? dbProduct = await _repository.GetByIdAsync(productId);
        if (dbProduct == null || dbProduct.LastUpdatedOnUtc < DateTime.UtcNow.AddDays(-7))
        {
            dbProduct = await _dataUpdater.UpdateProductByIdAsync(productId);
        }

        return dbProduct?.EntityToDomainModel();
    }

    public async Task<IReadOnlyCollection<ISearchResult>> ByNameAsync(string productname)
    {
        var searchResults = await _repository.SearchByNameAsync(productname);
        return searchResults.Select(x => x.EntityToDomainModel()).ToList();
    }
}