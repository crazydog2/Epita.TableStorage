using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace Epita.TableStorage.Gateway.Security
{
    public class SecurityManager
    {
        private const string applicationId = "ApplicationId";
        private readonly IHttpContextAccessor accessor;
        private readonly string securityKey;

        public SecurityManager(IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
            using RandomNumberGenerator rng = RandomNumberGenerator.Create();

            var data = new byte[64];
            rng.GetBytes(data);

            securityKey = Encoding.UTF8.GetString(data);
        }

        public async Task SignInAsync(string email)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(applicationId, securityKey)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties();
            
            await accessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        public bool IsPrincipalObsolete(ClaimsPrincipal principal)
        {
            string claim = principal.FindFirstValue(applicationId);

            if (string.IsNullOrEmpty(claim))
            {
                return false;
            }

            return !string.Equals(claim, securityKey);
        }
    }
}