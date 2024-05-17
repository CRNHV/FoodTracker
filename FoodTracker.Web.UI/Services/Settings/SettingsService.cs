using FoodTracker.Data.Domain.Application.User;
using FoodTracker.Web.UI.Models;
using FoodTracker.Web.UI.Models.Settings;
using System.Net.Http.Json;

namespace FoodTracker.Web.UI.Services.Settings;

internal class SettingsService : ISettingsService
{
    private readonly HttpClient _httpClient;

    public SettingsService(IHttpClientFactory clientFactory)
    {
        _httpClient = clientFactory.CreateClient("WebAPI");
    }

    public async Task<Result<IUserSettings>> GetForUserAsync()
    {
        var userSettings = await _httpClient.GetFromJsonAsync<UserSettingsModel>("/settings");
        if (userSettings == null)
        {
            return Results<IUserSettings>.Succes(new UserSettingsModel());
        }
        return Results<IUserSettings>.Succes(userSettings);
    }

    public async Task<Result<IUserSettings>> CreateOrUpdateAsync(UserSettingsModel settings)
    {
        var result = await _httpClient.PostAsJsonAsync("/settings", settings);
        return result.IsSuccessStatusCode ? Results<IUserSettings>.Succes(settings) : Results<IUserSettings>.Error("Unable to update settings.");
    }
}