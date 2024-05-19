using FoodTracker.Web.UI.Models.Login;
using FoodTracker.Web.UI.Services;
using Microsoft.AspNetCore.Components;

namespace FoodTracker.Web.UI;

public class AuthorizationHandler : DelegatingHandler
{
    private readonly NavigationManager _navigationManager;
    private readonly ILocalStorageService _localStorageService;

    public AuthorizationHandler(NavigationManager navigationManager, ILocalStorageService localStorageService)
    {
        _navigationManager = navigationManager;
        _localStorageService = localStorageService;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = await _localStorageService.GetItem<JwtToken>("token");
        if (token != null && !string.IsNullOrEmpty(token.Token))
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {token.Token}");

        try
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                // Redirect to the login page or perform any logout action
                _navigationManager.NavigateTo("/Logout", true);
            }

            return response;
        }
        catch (Exception)
        {
            // Redirect to the login page or perform any logout action
            _navigationManager.NavigateTo("/", true);
            throw;
        }
    }
}