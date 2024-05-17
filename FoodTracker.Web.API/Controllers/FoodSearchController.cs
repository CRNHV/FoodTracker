using FoodTracker.Contracts.Application.Products;
using FoodTracker.Web.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FoodTracker.Web.API.Controllers;

[ApiController]
[Route("/food/search")]
[Authorize]
public sealed class FoodSearchController : ControllerBase
{
    private readonly ILogger<FoodSearchController> _logger;
    private readonly IProductSearch _search;

    public FoodSearchController(ILogger<FoodSearchController> logger, IProductSearch search)
    {
        _logger = logger;
        _search = search;
    }

    [HttpGet("name/{name}")]
    public async Task<IActionResult> GetByName([FromRoute] string name)
    {
        var userId = HttpContext.User.GetClaimWithType(ClaimTypes.NameIdentifier).First();
        Guid requestId = Guid.NewGuid();

        _logger.LogInformation("UserId: {userId} started request: {requestId}, parameters: name={name}", userId.Value, requestId, name);

        var products = await _search.ByNameAsync(name);

        _logger.LogInformation("{requestId} | got {productsCount} search results.", userId.Value, products.Count);

        if (products.Count == 0)
            return NotFound();

        return Ok(products);
    }

    [HttpGet("ean/{ean}")]
    public async Task<IActionResult> GetByEan([FromRoute] string ean)
    {
        var userId = HttpContext.User.GetClaimWithType(ClaimTypes.NameIdentifier).First();
        Guid requestId = Guid.NewGuid();

        _logger.LogInformation("UserId: {userId} started request: {requestId}, parameters: ean={ean}", userId.Value, requestId, ean);

        var product = await _search.ByEanAsync(ean);

        _logger.LogInformation("{requestId} | got {productsCount} search results.", userId.Value, product == null ? 1 : 0);

        if (product is null)
            return NotFound();

        return Ok(product);
    }

    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        var userId = HttpContext.User.GetClaimWithType(ClaimTypes.NameIdentifier).First();
        Guid requestId = Guid.NewGuid();

        _logger.LogInformation("UserId: {userId} started request: {requestId}, parameters: id={id}", userId.Value, requestId, id);

        var product = await _search.ByIdAsync(id);

        _logger.LogInformation("{requestId} | got {productsCount} product search results.", userId.Value, product == null ? 1 : 0);

        if (product is null)
        {
            var baseProduct = await _search.BaseProductByIdAsync(id);
            _logger.LogInformation("{requestId} | got {productsCount} baseProduct search results.", userId.Value, product == null ? 1 : 0);
            product = baseProduct?.Products?.FirstOrDefault() ?? null;
        }

        return product != null ? Ok(product) : NotFound();
    }
}