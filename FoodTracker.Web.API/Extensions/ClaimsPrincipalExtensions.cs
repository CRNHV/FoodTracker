using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace FoodTracker.Web.API.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static IEnumerable<Claim> GetClaimWithType(this ClaimsPrincipal claimsPrincipal, string type)
    {
        return claimsPrincipal.Claims.Where(x => x.Type == type).ToArray();
    }
}