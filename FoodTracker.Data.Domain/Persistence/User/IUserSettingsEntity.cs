namespace FoodTracker.Data.Domain.Persistence.User;

public interface IUserSettingsEntity : IEntityBase
{
    int Id { get; set; }
    int UserId { get; set; }
    double EnergyGoal { get; set; }
    double ProteinGoal { get; set; }
    double FatGoal { get; set; }
    double CarbGoal { get; set; }
}