using FoodTracker.Data.Domain.Persistence.ProductTracking;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodTracker.Contracts.Persistence;

public interface IProductTrackerRepository
{
    Task<List<ITrackedMealEntity>> ListForUserIdAsync(int userId);

    Task<bool> AddMealAsync(string productId, int userId, string measurementUnit, int quantity);

    Task<bool> RemoveMealAsync(int trackedMealid, int userId);

    Task<List<ITrackedMealEntity>> ListForUserIdAsync(int userId, DateTime searchDate);
}