using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace FitnessRestApi.Middleware
{
    public class RoleClaimsTransformation : IClaimsTransformation
    {
        private readonly IConfiguration _config;

        public RoleClaimsTransformation(IConfiguration config)
        {
            _config = config;
        }

        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var identity = (ClaimsIdentity)principal.Identity!;
            var email = identity.FindFirst(ClaimTypes.Email)?.Value;

            // Example: make certain emails admins
            if (email == "admin@example.com")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
            }

            return Task.FromResult(principal);
        }
    }
}
