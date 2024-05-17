using FoodTracker.Contracts.Application.Products;
using FoodTracker.Contracts.DataProvider;
using FoodTracker.Contracts.Persistence;
using FoodTracker.Data.Persistence.Context;
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

        provider.AddDbContext<VoedingDbContext>(
                opt => opt.UseSqlServer(config.GetConnectionString("Store"))
            );
        provider.AddDbContext<VoedingIdentityContext>(
                opt => opt.UseSqlServer(config.GetConnectionString("Identity"))
            );
    }

    public static void AddProvider(this IServiceCollection provider)
    {
        provider.AddHttpClient();
        provider.AddScoped<IFoodDataProvider, VoedingAPI>();
    }
}