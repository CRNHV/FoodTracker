using FoodTracker.Data.Domain.Application.Product;
using FoodTracker.Web.UI.Models;
using FoodTracker.Web.UI.Models.Product;
using System.Net.Http.Json;

namespace FoodTracker.Web.UI.Services.Home;

public class FoodTrackService : IFoodTrackService
{
    private readonly HttpClient _httpClient;

    private const string SearchByNameUrl = "food/search/name";
    private const string SearchByEanUrl = "food/search/ean";
    private const string SearchByIdUrl = "food/search/id";
    private const string FoodListUrl = "food/list";

    public FoodTrackService(IHttpClientFactory clientFactory)
    {
        _httpClient = clientFactory.CreateClient("WebAPI");
    }

    public async Task<Result<IReadOnlyCollection<ISearchResult>>> SearchByNameAsync(string name)
    {
        try
        {
            string url = $"{SearchByNameUrl}/{name}";
            var result = await _httpClient.GetFromJsonAsync<List<SearchResultModel>>(url);
            if (result is null)
                return Results<IReadOnlyCollection<ISearchResult>>.Error("Your query returned no results.");
            return Results<IReadOnlyCollection<ISearchResult>>.Succes(result);
        }
        catch (Exception ex)
        {
            return Results<IReadOnlyCollection<ISearchResult>>.FromException(ex);
        }
    }

    public async Task<Result<IProduct>> SearchByEanAsync(string ean)
    {
        try
        {
            var url = $"{SearchByEanUrl}/{ean}";
            var result = await _httpClient.GetFromJsonAsync<Product>(url);
            if (result is null)
                return Results<IProduct>.Error("Your query returned no results.");
            return Results<IProduct>.Succes(result);
        }
        catch (Exception ex)
        {
            return Results<IProduct>.FromException(ex);
        }
    }

    public async Task<Result<IProduct>> SearchByIdAsync(string id)
    {
        try
        {
            var url = $"{SearchByIdUrl}/{id}";
            var result = await _httpClient.GetFromJsonAsync<Product>(url);
            if (result is null)
                return Results<IProduct>.Error("Your query returned no results.");
            return Results<IProduct>.Succes(result);
        }
        catch (Exception ex)
        {
            return Results<IProduct>.FromException(ex);
        }
    }

    public async Task<bool> AddFoodToEatListAsync(IProduct productInfo)
    {
        var result = await _httpClient.PostAsJsonAsync($"{FoodListUrl}", new FoodListItem()
        {
            Id = productInfo.Id
        });

        return result.IsSuccessStatusCode;
    }

    public async Task<bool> RemoveFoodFromEatListAsync(IProduct productInfo)
    {
        var result = await _httpClient.DeleteAsync($"/{FoodListUrl}/{productInfo.Id}");
        return result.IsSuccessStatusCode;
    }
}