using System.Collections.Generic;

namespace FoodTracker.Data.Domain.DataProvider;

public interface IBaseProductData
{
    string Id { get; set; }
    string Name { get; set; }
    IReadOnlyCollection<IProductData> Products { get; set; }
    IReadOnlyCollection<object> Synonyms { get; set; }
}