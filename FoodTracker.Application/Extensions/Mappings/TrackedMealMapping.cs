using FoodTracker.Application.TrackedMeals;
using FoodTracker.Data.Domain.Application.ProductTracking;
using FoodTracker.Data.Domain.Persistence.ProductTracking;

namespace FoodTracker.Application.Extensions.Mappings;

internal static class TrackedMealMapping
{
    public static ITrackedProduct ToDomainModel(this ITrackedMealEntity entity)
    {
        return new TrackedProduct()
        {
            CreatedOnUtc = entity.CreatedOnUtc,
            Id = entity.Id,
            Product = entity.Product.EntityToDomainModel(),
            Quantity = entity.Quantity,
            Unit = entity.Unit != null ? entity.Unit.EntityToDomainModel() : null,
            UserId = entity.UserId,
        };
    }
}