using FoodTracker.Data.Persistence.Entities.User;
using FoodTracker.Web.API.Extensions;
using FoodTracker.Web.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Web.API.Controllers;

[Route("[controller]")]
public sealed class AuthenticationController : ControllerBase
{
    private readonly ILogger<AuthenticationController> _logger;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IConfiguration _config;

    public AuthenticationController(ILogger<AuthenticationController> logger,
                                    UserManager<User> userManager,
                                    SignInManager<User> signInManager,
                                    IConfiguration config)
    {
        _logger = logger;
        _userManager = userManager;
        _signInManager = signInManager;
        _config = config;
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> Authorize([FromBody] AuthenticationRequest request)
    {
        Guid requestId = new Guid();

        _logger.LogInformation("Username: {username} started request: {requestId}", request.Username, requestId);

        var audience = _config["JWT:ValidAudience"];
        var issuer = _config["JWT:ValidIssuer"];
        var secret = _config["JWT:Secret"];

        var user = await _userManager.FindByNameAsync(request.Username);
        if (user is null)
        {
            _logger.LogWarning("{requestId} | Unable to login.", requestId);
            return Unauthorized();
        }

        var passwordCheck = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if (!passwordCheck.Succeeded)
        {
            _logger.LogWarning("{requestId} | Unable to login.", requestId);
            return Unauthorized();
        }

        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)); // Replace with your actual secret key
        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = await _userManager.GetClaimsAsync(user);
        if (claims == null || claims.Count == 0)
            return Unauthorized();

        JwtSecurityToken tokenGenerator = new JwtSecurityToken(
            issuer: issuer, // Replace with your issuer
            audience: audience, // Replace with your audience
            expires: DateTime.UtcNow.AddMinutes(120), // Token expiration time
            signingCredentials: creds,
            claims: claims
        );

        JwtSecurityTokenHandler tokenresult = new JwtSecurityTokenHandler();
        string token = tokenresult.WriteToken(tokenGenerator);

        return Ok(new { Token = token });
    }

    [HttpPost("Logout")]
    [AllowAnonymous]
    public async Task<IActionResult> Logout()
    {
        Guid requestId = new Guid();
        var userId = HttpContext.User.GetClaimWithType(ClaimTypes.NameIdentifier).First();
        _logger.LogInformation("Username: {userId} started request: {requestId}", userId.Value, requestId);
        await _signInManager.SignOutAsync();
        return Ok();
    }

    [HttpPost("Register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] AuthenticationRequest request)
    {
        var userId = HttpContext.User.GetClaimWithType(ClaimTypes.NameIdentifier).First();
        Guid requestId = Guid.NewGuid();

        _logger.LogInformation("UserId: {userId} started request: {requestId}, parameters: username={username}", userId.Value, requestId, request.Username);

        var newUser = new User();
        newUser.UserName = request.Username;

        var identityUser = await _userManager.CreateAsync(newUser, request.Password);
        if (!identityUser.Succeeded)
        {
            _logger.LogInformation("{requestId} | user with {username} could not be created by {userId}", requestId, request.Username, userId.Value);
            return Unauthorized(identityUser.Errors.Select(x => x.Description).ToList());
        }

        var createdUser = await _userManager.FindByNameAsync(newUser.UserName);
        if (createdUser is null)
        {
            _logger.LogInformation("{requestId} | user with {username} could not be found after creation", requestId, request.Username);
            return Unauthorized();
        }

        await _userManager.AddClaimAsync(createdUser, new Claim(ClaimTypes.Role, "user"));
        await _userManager.AddClaimAsync(createdUser, new Claim(ClaimTypes.Name, newUser.UserName));
        await _userManager.AddClaimAsync(createdUser, new Claim(ClaimTypes.NameIdentifier, newUser.Id.ToString()));
        return Ok();
    }
}