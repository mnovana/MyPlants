using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPlants.Interfaces;
using MyPlants.Models;

namespace MyPlants.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            try
            {
                string token = await _authenticationService.LoginAsync(loginDTO.Email, loginDTO.Password);
                return Ok(new { token, loginDTO.Email });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
