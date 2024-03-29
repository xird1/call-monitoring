using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TelusInternational.Business;
using TelusInternational.Business.Dto;

namespace TelusInternational.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userService.ValidateCredentials(model);
                if (existingUser != null)
                {
                    // just return user ok for now, no need claims and token
                    return Ok(existingUser);
                }
            }
            return BadRequest();
        }
    }
}
