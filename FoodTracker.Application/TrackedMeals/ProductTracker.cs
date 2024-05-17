using FoodTracker.Application.Extensions.Mappings;
using FoodTracker.Contracts.Application.ProductTracking;
using FoodTracker.Contracts.Persistence;
using FoodTracker.Data.Domain.Application.ProductTracking;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodTracker.Application.TrackedMeals;

internal class ProductTracker : IProductTracker
{
    private readonly IProductTrackerRepository _repository;

    public ProductTracker(IProductTrackerRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> AddMealToTrackedList(string productId, int userId, string measurementUnitId, int quantity)
    {
        return await _repository.AddMealAsync(productId, userId, measurementUnitId, quantity);
    }

    public async Task<ICollection<ITrackedProduct>> GetMealsForUserId(int userId)
    {
        var meals = await _repository.ListForUserIdAsync(userId);
        return meals.ConvertAll(x => x.ToDomainModel());
    }

    public async Task<ICollection<ITrackedProduct>> GetMealsForUserId(int userId, DateTime searchDate)
    {
        var meals = await _repository.ListForUserIdAsync(userId, searchDate);
        return meals.ConvertAll(x => x.ToDomainModel());
    }

    public async Task<bool> RemoveMealFromTrackedList(int trackedMealid, int userId)
    {
        return await _repository.RemoveMealAsync(trackedMealid, userId);
    }
}