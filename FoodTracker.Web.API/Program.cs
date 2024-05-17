using FoodTracker.Application.Extensions;
using FoodTracker.Data.Persistence.Context;
using FoodTracker.Data.Persistence.Entities.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Text;

namespace FoodTracker.Web.API;

public class Program
{
    public static void Main(string[] args)
    {
        var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        var builder = WebApplication.CreateBuilder(args);
        ConfigurationManager configuration = builder.Configuration;

        builder.Services.AddLogging();

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddVoedingLib(configuration);

        builder.Services.AddIdentityCore<User>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = configuration["JWT:ValidAudience"],
                ValidIssuer = configuration["JWT:ValidIssuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
            };
        });

        var corsSection = configuration.GetSection("cors");
        var originsSection = corsSection.GetSection("origins");

        if (originsSection is null)
            throw new System.Exception("Unable to load CORS origins.");

        var originsEnumerable = originsSection.AsEnumerable();
        var origins = originsEnumerable
            .Where(x => x.Value != null)
            .Select(x => x.Value)
            .ToArray();

        if (origins.Length == 0)
            throw new System.Exception("No CORS origins defined.");

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins,
                              policy =>
                              {
                                  policy
                                    .WithOrigins(origins)
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                              });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseCors(MyAllowSpecificOrigins);

        app.MapControllers();

        app.Run();
    }
}