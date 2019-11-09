using System.Threading.Tasks;
using Epita.TableStorage.Gateway.Requests;
using Epita.TableStorage.Gateway.Security;
using Epita.TableStorage.Logic.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Epita.TableStorage.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly SecurityManager securityManager;
        private readonly IUserLogic userLogic;

        public LoginController(
            SecurityManager securityManager,
            IUserLogic userLogic)
        {
            this.securityManager = securityManager;
            this.userLogic = userLogic;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string userId = await userLogic.LoginAsync(loginRequest.Email, loginRequest.Password).ConfigureAwait(false);

            if (string.IsNullOrEmpty(userId))
            {
                return NotFound();
            }

            await securityManager.SignInAsync(loginRequest.Email).ConfigureAwait(false);

            return Ok();
        }
    }
}