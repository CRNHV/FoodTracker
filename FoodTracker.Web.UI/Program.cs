using FoodTracker.Web.UI.Services;
using FoodTracker.Web.UI.Services.Home;
using FoodTracker.Web.UI.Services.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace FoodTracker.Web.UI;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        if (!builder.HostEnvironment.IsDevelopment())
        {
            builder.Logging.SetMinimumLevel(LogLevel.None);
        }

        var baseAddress = builder.Configuration.GetValue<string>("BaseAddress");

        if (baseAddress is null)
        {
            return;
        }

        builder.Services.AddScoped<AuthorizationHandler>();

        builder.Services.AddHttpClient("WebAPI", conf =>
        {
            conf.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<AuthorizationHandler>();

        builder.Services.AddScoped<IFoodTrackService, FoodTrackService>();
        builder.Services.AddScoped<ISettingsService, SettingsService>();

        // Authentication and Authorization
        builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
        builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();        
        builder.Services.AddAuthorizationCore(options =>
        {
            options.FallbackPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
        });
        builder.Services.AddCascadingAuthenticationState();
        builder.Services.AddOptions();
                
        
        var host = builder.Build();
        var services = host.Services;

        await host.RunAsync();
    }
}