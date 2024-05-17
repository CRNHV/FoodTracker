using FoodTracker.Data.Domain.Application.User;

namespace FoodTracker.Web.UI.Models.Settings;

public class UserSettingsModel : IUserSettings
{
    public double EnergyGoal { get; set; } = 0;
    public double ProteinGoal { get; set; } = 0;
    public double FatGoal { get; set; } = 0;
    public double CarbGoal { get; set; } = 0;
}