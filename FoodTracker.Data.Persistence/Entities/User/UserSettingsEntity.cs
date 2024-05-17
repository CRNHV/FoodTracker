using FoodTracker.Data.Domain.Persistence.User;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTracker.Data.Persistence.Entities.User;

internal class UserSettingsEntity : IUserSettingsEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int UserId { get; set; }
    public double EnergyGoal { get; set; }
    public double ProteinGoal { get; set; }
    public double FatGoal { get; set; }
    public double CarbGoal { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime LastUpdatedOnUtc { get; set; }
}