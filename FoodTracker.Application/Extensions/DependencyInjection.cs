using FoodTracker.Application.Authentication;
using FoodTracker.Application.TrackedMeals;
using FoodTracker.Application.User;
using FoodTracker.Contracts.Application.Authentication;
using FoodTracker.Contracts.Application.Products;
using FoodTracker.Contracts.Application.ProductTracking;
using FoodTracker.Contracts.Application.User;
using FoodTracker.Data.Persistence.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FoodTracker.Provider.VoedingCentrum;
using FoodTracker.Application.TrackedMeals.Products;

namespace FoodTracker.Application.Extensions;

public static class DependencyInjection
{
    public static void AddVoedingLib(this IServiceCollection provider, ConfigurationManager configuration)
    {
        provider.AddApplication();
        provider.AddPersistence(configuration);
        provider.AddProvider(configuration);
    }

    public static void AddApplication(this IServiceCollection provider)
    {
        provider.AddScoped<IProductTracker, ProductTracker>();
        provider.AddScoped<IUserAuthentication, AuthenticationHandler>();
        provider.AddScoped<IProductSearch, ProductSearch>();
        provider.AddScoped<ISettings, SettingsService>();
        provider.AddScoped<IRegistrationTokens, RegistrationTokenService>();
    }
}