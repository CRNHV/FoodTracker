using FoodTracker.Data.Domain.Persistence.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodTracker.Contracts.Persistence;

public interface IProductRepository
{
    Task<IBaseProductEntity?> GetBaseProductByIdAsync(string productId);

    Task<IProductEntity?> GetByEanAsync(string ean);

    Task<IProductEntity?> GetByIdAsync(string productId);

    Task InsertOrUpdateAsync(IBaseProductEntity dbEntity);

    Task InsertAsync(IProductEntity productEntity);

    Task<IReadOnlyCollection<ISearchResultEntity>> SearchByNameAsync(string name);

    Task<IEnumerable<IMeasurementUnitEntity>> GetExistingUnitsAsync();
}