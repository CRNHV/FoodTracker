using FoodTracker.Contracts.Persistence;
using FoodTracker.Data.Domain.Persistence.ProductTracking;
using FoodTracker.Data.Persistence.Context;
using FoodTracker.Data.Persistence.Entities.ProductTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTracker.Data.Persistence.Repositories;

internal class ProductTrackerRepository : IProductTrackerRepository
{
    private readonly FoodTrackerDbContext _context;

    public ProductTrackerRepository(FoodTrackerDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddMealAsync(string productId, int userId, string measurementUnit, int quantity)
    {
        var trackedMeal = new TrackedMealEntity()
        {
            ProductId = productId,
            UserId = userId,
            CreatedOnUtc = DateTime.UtcNow,
            LastUpdatedOnUtc = DateTime.UtcNow,
            MeasurementUnitId = measurementUnit,
            Quantity = quantity
        };

        await _context.TrackedMeals.AddAsync(trackedMeal);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<List<ITrackedMealEntity>> ListForUserIdAsync(int userId)
    {
        var meals = await _context.TrackedMeals
            .Include(x => x.Product)
            .ThenInclude(x => x.ProductInfo)
            .Where(x => x.UserId == userId)
            .ToListAsync();
        return meals.ConvertAll(x => (ITrackedMealEntity)x);
    }

    public async Task<List<ITrackedMealEntity>> ListForUserIdAsync(int userId, DateTime searchDate)
    {
        var meals = await _context.TrackedMeals
            .Include(x => x.Product)
            .ThenInclude(x => x.ProductInfo)
            .Where(x => x.UserId == userId && x.CreatedOnUtc.Date.Date == searchDate.Date)
            .ToListAsync();

        return meals.ConvertAll(x => (ITrackedMealEntity)x);
    }

    public async Task<bool> RemoveMealAsync(int trackedMealid, int userId)
    {
        var trackedMeal = await _context.TrackedMeals.FirstOrDefaultAsync(x => x.Id == trackedMealid && x.UserId == userId);
        if (trackedMeal != null)
        {
            _context.Remove(trackedMeal);
            return await _context.SaveChangesAsync() > 0;
        }

        return false;
    }
}