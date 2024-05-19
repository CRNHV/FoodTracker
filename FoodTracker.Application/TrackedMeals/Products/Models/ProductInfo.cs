using FoodTracker.Data.Domain.Application.Product;

namespace FoodTracker.Application.TrackedMeals.Products.Models;

internal class ProductInfo : IProductInfo
{
    public double? Eiwit { get; set; }
    public double? EiwitPlantaardig { get; set; }
    public double? Suikers { get; set; }
    public double? VerzadigdVet { get; set; }
    public double? Vet { get; set; }
    public double? Vezels { get; set; }
    public double? Koolhydraten { get; set; }
    public double? Energie { get; set; }
}