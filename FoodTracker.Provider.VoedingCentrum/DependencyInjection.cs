using FoodTracker.Contracts.DataProvider;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace FoodTracker.Provider.VoedingCentrum;
public static class DependencyInjection
{
    public static void AddProvider(this IServiceCollection provider, IConfiguration config)
    {
        var voedingCentrumSettings = config.GetSection("VoedingCentrumAPI");
        var sectionDict = voedingCentrumSettings.AsEnumerable();

        provider.AddHttpClient(Options.DefaultName, conf =>
        {
            conf.BaseAddress = new Uri("https://api3-mijn.voedingscentrum.nl/api/");
            foreach (var item in sectionDict)
            {
                if (item.Key == null || item.Value == null)
                    continue;

                var key = item.Key.Split(':')[1];

                var added = conf.DefaultRequestHeaders.TryAddWithoutValidation(key, item.Value);
                if (!added)
                {
                    Console.Write($"Not added {key} {item.Value}");
                }
            }
        });
        provider.AddScoped<IFoodDataProvider, VoedingAPI>();
    }
}