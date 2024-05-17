using FoodTracker.Contracts.Application.ProductTracking;
using FoodTracker.Web.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FoodTracker.Web.API.Controllers;

[ApiController]
[Route("food/list")]
[Authorize]
public class FoodListController : ControllerBase
{
    private readonly IProductTracker _tracker;
    private readonly ILogger<FoodListController> _logger;

    public FoodListController(IProductTracker tracker, ILogger<FoodListController> logger)
    {
        _tracker = tracker;
        _logger = logger;
    }

    [HttpPost()]
    public async Task<IActionResult> AddToList([FromBody] FoodListRequest request)
    {
        var userId = HttpContext.User.GetClaimWithType(ClaimTypes.NameIdentifier).First();
        Guid requestId = Guid.NewGuid();

        _logger.LogInformation("UserId: {userId} started request: {requestId}, parameters: productId={productId}", userId.Value, requestId, request.Id);

        if (!int.TryParse(userId.Value, out var userIdInt))
        {
            _logger.LogWarning("{requestId} | Unable to parse userId claim value: {claim}, value: {claimValue}", requestId, userId, userId.Value);
            return BadRequest();
        }

        await _tracker.AddMealToTrackedList(request.Id, userIdInt, "0970056b-5be2-4dc1-909b-5afb1dc7ea7c", 0);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveFromList([FromRoute] int trackedMealId)
    {
        var userId = HttpContext.User.GetClaimWithType(ClaimTypes.NameIdentifier).First();
        Guid requestId = Guid.NewGuid();

        _logger.LogInformation("UserId: {userId} started request: {requestId}, parameters: trackedMealId={trackedMealId}", userId.Value, requestId, trackedMealId);

        if (!int.TryParse(userId.Value, out var userIdInt))
        {
            _logger.LogWarning("{requestId} | Unable to parse userId claim value: {claim}, value: {claimValue}", requestId, userId, userId.Value);
            return BadRequest();
        }

        await _tracker.RemoveMealFromTrackedList(trackedMealId, userIdInt);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> ListFood()
    {
        var userId = HttpContext.User.GetClaimWithType(ClaimTypes.NameIdentifier).First();
        Guid requestId = Guid.NewGuid();

        _logger.LogInformation("UserId: {userId} started request: {requestId}", userId.Value, requestId);

        if (!int.TryParse(userId.Value, out var userIdInt))
        {
            _logger.LogWarning("{requestId} | Unable to parse userId claim value: {claim}, value: {claimValue}", requestId, userId, userId.Value);
            return BadRequest();
        }

        var meals = await _tracker.GetMealsForUserId(userIdInt);
        return Ok(meals);
    }

    [HttpGet("{date}")]
    public async Task<IActionResult> ListFoodByDate([FromRoute] string date)
    {
        var searchDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        var userId = HttpContext.User.GetClaimWithType(ClaimTypes.NameIdentifier).First();
        Guid requestId = Guid.NewGuid();

        _logger.LogInformation("UserId: {userId} started request: {requestId}", userId.Value, requestId);

        if (!int.TryParse(userId.Value, out var userIdInt))
        {
            _logger.LogWarning("{requestId} | Unable to parse userId claim value: {claim}, value: {claimValue}", requestId, userId, userId.Value);
            return BadRequest();
        }

        var meals = await _tracker.GetMealsForUserId(userIdInt, searchDate);
        return Ok(meals);
    }
}

public class FoodListRequest
{
    public string Id { get; set; }
}