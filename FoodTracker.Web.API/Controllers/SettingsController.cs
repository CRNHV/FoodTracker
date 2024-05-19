using FoodTracker.Contracts.Application.User;
using FoodTracker.Data.Persistence.Entities.User;
using FoodTracker.Web.API.Extensions;
using FoodTracker.Web.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FoodTracker.Web.API.Controllers;

[ApiController]
[Route("/settings")]
[Authorize]
public sealed class SettingsController : ControllerBase
{
    private readonly ILogger<SettingsController> _logger;
    private readonly UserManager<User> _userManager;
    private readonly ISettings _settings;

    public SettingsController(ILogger<SettingsController> logger,
                                    UserManager<User> userManager,
                                    ISettings settings)
    {
        _logger = logger;
        _userManager = userManager;
        _settings = settings;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        Guid requestId = Guid.NewGuid();
        var userId = HttpContext.User.GetClaimWithType(ClaimTypes.NameIdentifier).First();

        _logger.LogInformation("UserId: {userId} started request: {requestId}", userId.Value, requestId);

        if (!int.TryParse(userId.Value, out var userIdInt))
        {
            _logger.LogWarning("{requestId} | Unable to parse userId claim value: {claim}, value: {claimValue}", requestId, userId, userId.Value);
            return BadRequest();
        }

        var userSettings = await _settings.GetForUserAsync(userIdInt);
        return Ok(userSettings);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrUpdate([FromBody] UserSettingsRequest request)
    {
        Guid requestId = Guid.NewGuid();
        var userId = HttpContext.User.GetClaimWithType(ClaimTypes.NameIdentifier).First();
        _logger.LogInformation("UserId: {userId} started request: {requestId} request params: {requestParams}", userId.Value, requestId, request);

        if (!int.TryParse(userId.Value, out var userIdInt))
        {
            _logger.LogWarning("{requestId} | Unable to parse userId claim value: {claim}, value: {claimValue}", requestId, userId, userId.Value);
            return BadRequest();
        }

        await _settings.CreateOrUpdate(userIdInt, request.EnergyGoal, request.ProteinGoal, request.FatGoal, request.CarbGoal);

        return Ok();
    }
}