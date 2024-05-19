using FoodTracker.Contracts.DataProvider;
using FoodTracker.Data.Domain.DataProvider;
using FoodTracker.Provider.VoedingCentrum.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FoodTracker.Provider.VoedingCentrum;

public sealed class VoedingAPI : IFoodDataProvider
{
    private readonly HttpClient _httpClient;

    public VoedingAPI(IHttpClientFactory clientFactory, IConfiguration config)
    {
        _httpClient = clientFactory.CreateClient();
    }

    public async Task<IReadOnlyCollection<IProductSearchResultData>> SearchByNameAsync(string productname)
    {
        var query = productname.Replace(" ", "+");
        var data = await _httpClient.GetFromJsonAsync<List<SearchResultData>>($"search/31?query={query}") ?? [];
        return data;
    }

    public async Task<IProductInfoData?> SearchByEanAsync(string ean)
    {
        var data = await _httpClient.GetFromJsonAsync<ProductInfoData>($"brandproduct/ean/{ean}");
        return data;
    }

    public async Task<IProductInfoData?> SearchByProductIdAsync(string productId)
    {
        var data = await _httpClient.GetFromJsonAsync<ProductInfoData>($"brandproduct/{productId}");
        return data;
    }

    public async Task<IBaseProductData?> SearchBaseProductByIdAsync(string productId)
    {
        var data = await _httpClient.GetFromJsonAsync<BaseProductData>($"baseproduct/{productId}");
        return data;
    }
}