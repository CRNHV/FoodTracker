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
using System;
using System.Threading.Tasks;

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

    public static async Task RunDbMigrations(this IServiceProvider provider)
    {
        using (var scope = provider.CreateScope())
        {
            var context = scope.ServiceProvider.GetService<FoodTrackerDbContext>();
            if (context is null)
                throw new Exception("Unable to get context from ServiceProvider");
            context.Database.Migrate();

            var appHasUsers = await context.Users.AnyAsync();
            var appHasRegistrationTokens = await context.RegistrationTokens.AnyAsync();
            if (!appHasUsers && !appHasRegistrationTokens)
            {
                var token = Guid.NewGuid();
                var currentDtUtc = DateTime.UtcNow;

                await context.RegistrationTokens.AddAsync(new RegistrationTokenEntity()
                {
                    CreatedOnUtc = currentDtUtc,
                    LastUpdatedOnUtc = currentDtUtc,
                    Token = token
                });

                await context.SaveChangesAsync();
                await Console.Out.WriteLineAsync($"One time registration token: {token}");
            }
        }
    }
}