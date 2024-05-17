using FoodTracker.Web.UI.Services;
using FoodTracker.Web.UI.Services.Home;
using FoodTracker.Web.UI.Services.Settings;
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

        builder.Services.AddScoped<AuthorizationHandler>();

        builder.Services.AddHttpClient("WebAPI", conf =>
        {
            conf.BaseAddress = new Uri("https://localhost:7281");
        }).AddHttpMessageHandler<AuthorizationHandler>();

        builder.Services.AddScoped<IFoodTrackService, FoodTrackService>();
        builder.Services.AddCascadingAuthenticationState();
        builder.Services.AddOptions();
        builder.Services.AddAuthorizationCore();
        builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
        builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
        builder.Services.AddScoped<ISettingsService, SettingsService>();

        var host = builder.Build();
        var services = host.Services;

        await host.RunAsync();
    }
}