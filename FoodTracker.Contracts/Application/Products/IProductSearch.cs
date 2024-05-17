using FoodTracker.Data.Domain.Application.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodTracker.Contracts.Application.Products;

public interface IProductSearch
{
    Task<IProduct?> ByEanAsync(string ean);

    Task<IProduct?> ByIdAsync(string productId);

    Task<IBaseProduct?> BaseProductByIdAsync(string productId);

    Task<IReadOnlyCollection<ISearchResult>> ByNameAsync(string productname);
}