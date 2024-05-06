using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using System.Threading.Tasks;
using BLL.ModelViews;

namespace API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginMV model)
        {
            var result = await _authenticationService.AuthenticateAsync(HttpContext, model.Username, model.Password);

            if (result.Succeeded)
            {
                return Ok(new { message = "Login successful" });
            }
            else
            {
                return BadRequest(new { message = "Invalid username or password" });
            }

        }

    }
}
