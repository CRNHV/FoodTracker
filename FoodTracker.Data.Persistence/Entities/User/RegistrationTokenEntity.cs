using FoodTracker.Data.Domain.Persistence.User;
using System;
using System.ComponentModel.DataAnnotations;

namespace FoodTracker.Data.Persistence.Entities.User;
internal class RegistrationTokenEntity : IRegistrationTokenEntity
{
    public DateTime CreatedOnUtc { get; set; }
    public DateTime LastUpdatedOnUtc { get; set; }
    [Key]
    public Guid Token { get; set; }
}
