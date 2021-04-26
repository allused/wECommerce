using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wECommerce.Models.User;
using wECommerce.Models.UserManager;
using wECommerce.Services;

namespace wECommerce.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterUser userModel)
        {
            if (ModelState.IsValid)
            {
                var result = await userService.RegisterUserAsync(userModel);

                if (result.IsSuccesful)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            return BadRequest("Some properties are invalid");
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginUser userModel)
        {
            if (ModelState.IsValid)
            {
                var result = await userService.LoginAsync(userModel);

                if (result.IsSuccesful)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            return BadRequest("Some properties are invalid");
        }
    }
}
