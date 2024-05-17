using System;

namespace FoodTracker.Data.Domain.Persistence;

public interface IEntityBase
{
    public DateTime CreatedOnUtc { get; set; }
    public DateTime LastUpdatedOnUtc { get; set; }
}