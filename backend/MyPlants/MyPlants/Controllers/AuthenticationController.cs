using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPlants.Interfaces;

namespace MyPlants.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            try
            {
                string token = await _authenticationService.LoginAsync(email, password);
                return Ok(new { token, email });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
