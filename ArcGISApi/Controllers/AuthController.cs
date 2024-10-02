using ArcGISApi.DTO;
using ArcGISApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArcGISApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtAuthService _jwtAuthService;

        public AuthController(IJwtAuthService jwtAuthService)
        {
            _jwtAuthService = jwtAuthService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO loginDto)
        {
            var token = _jwtAuthService.GenerateToken(loginDto.Username, loginDto.Password);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }
    }
}
