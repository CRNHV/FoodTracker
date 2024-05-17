namespace FoodTracker.Web.API.Models;

public class UserSettingsRequest
{
    public double EnergyGoal { get; set; }
    public double ProteinGoal { get; set; }
    public double FatGoal { get; set; }
    public double CarbGoal { get; set; }
}