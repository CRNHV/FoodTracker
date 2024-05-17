using FoodTracker.Data.Domain.Persistence.Product;
using System.Threading.Tasks;

namespace FoodTracker.Contracts.Application.Products;

public interface IDataUpdater
{
    Task<IBaseProductEntity?> UpdateBaseProductByProductIdAsync(string productId);

    Task<IProductEntity?> UpdateProductByEanAsync(string ean);

    Task<IProductEntity?> UpdateProductByIdAsync(string productId);
}