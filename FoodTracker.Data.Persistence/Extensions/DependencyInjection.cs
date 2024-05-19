using FoodTracker.Contracts.Application.Products;
using FoodTracker.Contracts.DataProvider;
using FoodTracker.Contracts.Persistence;
using FoodTracker.Data.Persistence.Context;
using FoodTracker.Data.Persistence.Entities.User;
using FoodTracker.Data.Persistence.Repositories;
using FoodTracker.Provider.VoedingCentrum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodTracker.Data.Persistence.Extensions;

public static class DependencyInjection
{
    public static void AddPersistence(this IServiceCollection provider, IConfiguration config)
    {
        provider.AddScoped<IProductRepository, ProductRepository>();
        provider.AddScoped<IDataUpdater, ProductUpdater>();
        provider.AddScoped<IProductTrackerRepository, ProductTrackerRepository>();
        provider.AddScoped<ISettingsRepository, UserSettingsRepository>();
        provider.AddScoped<IRegistrationTokenRepository, RegistrationTokenRepository>();

        provider
            .AddIdentityCore<User>()
            .AddEntityFrameworkStores<FoodTrackerDbContext>();

        provider.AddDbContext<FoodTrackerDbContext>(
                opt => opt.UseSqlServer(config.GetConnectionString("FoodTrackerDb"))
            );
    }

    public static void AddProvider(this IServiceCollection provider)
    {
        provider.AddHttpClient();
        provider.AddScoped<IFoodDataProvider, VoedingAPI>();
    }
}