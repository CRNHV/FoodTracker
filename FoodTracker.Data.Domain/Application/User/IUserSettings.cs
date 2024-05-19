namespace FoodTracker.Data.Domain.Application.User;

public interface IUserSettings
{
    double EnergyGoal { get; set; }
    double ProteinGoal { get; set; }
    double FatGoal { get; set; }
    double CarbGoal { get; set; }
}