using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epita.TableStorage.Gateway.Requests;
using Epita.TableStorage.Logic.Contracts;
using Epita.TableStorage.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Epita.TableStorage.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserLogic userLogic;

        public UsersController(IUserLogic userLogic)
        {
            this.userLogic = userLogic;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] UserCreationRequest creationRequest)
        {
            string userId = await userLogic.CreateAsync(creationRequest.User, creationRequest.Password);

            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetByIdAsync), new { userId }, userId);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery]Role? role = null)
        {
            IEnumerable<User> users = await userLogic.GetAsync(role).ConfigureAwait(false);

            if (users == null)
            {
                return Ok(Enumerable.Empty<User>());
            }

            return Ok(users);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetByIdAsync(string userId)
        {
            User user = await userLogic.GetByIdAsync(userId).ConfigureAwait(false);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateByIdAsync(string userId, [FromBody]UserInformation userInformation)
        {
            bool success = await userLogic.UpdateByIdAsync(userId, userInformation).ConfigureAwait(false);

            if (success)
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}