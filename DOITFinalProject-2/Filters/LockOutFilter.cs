using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;

namespace DOITFinalProject_2.Filters
{
    public sealed class LockOutFilter : IAsyncAuthorizationFilter
    {        
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                var userManager = context.HttpContext.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();
                var signInManager = context.HttpContext.RequestServices.GetRequiredService<SignInManager<ApplicationUser>>();
                
                var user = await userManager.GetUserAsync(context.HttpContext.User);

                if (user != null && await userManager.IsLockedOutAsync(user))
                {
                    await signInManager.SignOutAsync();
                    context.Result = new UnauthorizedObjectResult("you are banned");
                    return;
                }
                return;
            }            
            return;
        }

    }
}
