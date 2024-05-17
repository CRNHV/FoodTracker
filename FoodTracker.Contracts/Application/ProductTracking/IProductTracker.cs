using FoodTracker.Data.Domain.Application.ProductTracking;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodTracker.Contracts.Application.ProductTracking;

public interface IProductTracker
{
    Task<ICollection<ITrackedProduct>> GetMealsForUserId(int userId);

    Task<bool> AddMealToTrackedList(string productId, int userId, string measurementUnitId, int quantity);

    Task<bool> RemoveMealFromTrackedList(int trackedMealid, int userId);

    Task<ICollection<ITrackedProduct>> GetMealsForUserId(int userIdInt, DateTime searchDate);
}