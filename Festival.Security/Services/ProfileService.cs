using Festival.Security.Models;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Festival.Security.Services
{
    public class ProfileService : IProfileService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public ProfileService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = await userManager.GetUserAsync(context.Subject);
            var userRoles = await userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();
            foreach (var role in userRoles)
            {
                roleClaims.Add(new Claim("roles", role));
                roleClaims.Add(new Claim("email", user.Email));
                roleClaims.Add(new Claim("username", user.UserName));
            }

            context.IssuedClaims.AddRange(roleClaims);
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await userManager.FindByIdAsync(sub);
            context.IsActive = user != null;
        }
    }
}
