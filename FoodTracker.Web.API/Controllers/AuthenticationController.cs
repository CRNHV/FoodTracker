using FoodTracker.Contracts.Application.User;
using FoodTracker.Data.Domain.Application.Authentication;
using FoodTracker.Data.Persistence.Entities.User;
using FoodTracker.Web.API.Extensions;
using FoodTracker.Web.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
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
    private readonly IRegistrationTokens _registrationTokens;

    private readonly string? JwtAudience;
    private readonly string? JwtIssuer;
    private readonly string? JwtSecret;

    public AuthenticationController(ILogger<AuthenticationController> logger,
                                    UserManager<User> userManager,
                                    SignInManager<User> signInManager,
                                    IConfiguration config,
                                    IRegistrationTokens registrationTokens)
    {
        _logger = logger;
        _userManager = userManager;
        _signInManager = signInManager;
        _config = config;
        _registrationTokens = registrationTokens;

        JwtAudience = _config["JWT:ValidAudience"];
        JwtIssuer = _config["JWT:ValidIssuer"];
        JwtSecret = _config["JWT:Secret"];
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> Authorize([FromBody] AuthenticationRequest request)
    {
        Guid requestId = Guid.NewGuid();

        _logger.LogInformation("Username: {username} started request: {requestId}", request.Username, requestId);



        var user = await _userManager.FindByNameAsync(request.Username);
        if (user is null)
        {
            _logger.LogWarning("{requestId} | Unable to login due to the username not found.", requestId);
            return Unauthorized();
        }

        var passwordCheck = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if (!passwordCheck.Succeeded)
        {
            _logger.LogWarning("{requestId} | Unable to login due to a password mismatch", requestId);
            return Unauthorized();
        }

        var token = await GenerateTokenAsync(user);
        if (token is null)
        {
            _logger.LogInformation("{requestId} | unable to generate token for {username}", requestId, request.Username);
            return Unauthorized();
        }

        _logger.LogInformation("{requestId} | {username} logged in succesfully", requestId, request.Username);
        return Ok(new { Token = token });
    }

    [HttpPost("Logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        Guid requestId = Guid.NewGuid();
        var userId = HttpContext.User.GetClaimWithType(ClaimTypes.NameIdentifier).First();
        _logger.LogInformation("Username: {userId} started request: {requestId}", userId.Value, requestId);
        await _signInManager.SignOutAsync();
        return Ok();
    }

    [HttpPost("Token")]
    [Authorize]
    public async Task<IActionResult> CreateToken()
    {
        Guid requestId = Guid.NewGuid();
        var userId = HttpContext.User.GetClaimWithType(ClaimTypes.NameIdentifier).First();
        _logger.LogInformation("Username: {userId} started request: {requestId}", userId.Value, requestId);

        var token = await _registrationTokens.CreateTokenAsync();
        if (token.Token == Guid.Empty)
        {
            return BadRequest();
        }

        _logger.LogInformation("{requestId} | created token: {token}", requestId, token.Token);

        return Ok(new
        {
            token.Token,
        });
    }

    [HttpPost("Register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegistrationRequest request)
    {
        Guid requestId = Guid.NewGuid();

        _logger.LogInformation("Started request: {requestId}, parameters: username={username}", requestId, request.Username);

        var token = await _registrationTokens.GetTokenAsync(request.Token);
        if (token is null || token.IsUsed || token.Token == Guid.Empty)
        {
            _logger.LogInformation("{requestId} | supplied token {tokenId} by {username} is already used.", requestId, request.Token, request.Username);
            return Unauthorized();
        }

        var newUser = new User();
        newUser.UserName = request.Username;

        var identityUser = await _userManager.CreateAsync(newUser, request.Password);
        if (!identityUser.Succeeded)
        {
            _logger.LogInformation("{requestId} | user with {username} could not be created", requestId, request.Username);
            return Unauthorized(identityUser.Errors.Select(x => x.Description).ToList());
        }

        var createdUser = await _userManager.FindByNameAsync(newUser.UserName);
        if (createdUser is null)
        {
            _logger.LogInformation("{requestId} | user with {username} could not be found after creation", requestId, request.Username);
            return Unauthorized();
        }

        await _registrationTokens.SetTokenUsedAsync(request.Token);

        _logger.LogInformation("{requestId} | {username} registered succesfully", requestId, request.Username);

        await _userManager.AddClaimAsync(createdUser, new Claim(ClaimTypes.Role, "user"));
        await _userManager.AddClaimAsync(createdUser, new Claim(ClaimTypes.Name, newUser.UserName));
        await _userManager.AddClaimAsync(createdUser, new Claim(ClaimTypes.NameIdentifier, newUser.Id.ToString()));

        var loginToken = await GenerateTokenAsync(createdUser);
        if (loginToken is null)
        {
            return Ok(new
            {
                Token = string.Empty
            });
        }

        return Ok(new
        {
            Token = loginToken
        });
    }

    private async Task<string?> GenerateTokenAsync(User user)
    {
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSecret)); // Replace with your actual secret key
        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = await _userManager.GetClaimsAsync(user);
        if (claims == null || claims.Count == 0)
            return null;

        JwtSecurityToken tokenGenerator = new JwtSecurityToken(
            issuer: JwtIssuer, // Replace with your issuer
            audience: JwtAudience, // Replace with your audience
            expires: DateTime.UtcNow.AddMinutes(120), // Token expiration time
            signingCredentials: creds,
            claims: claims
        );

        JwtSecurityTokenHandler tokenresult = new JwtSecurityTokenHandler();
        string token = tokenresult.WriteToken(tokenGenerator);
        return token;
    }
}