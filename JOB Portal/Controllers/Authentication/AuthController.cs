using Application.JOB.Interfaces;
using Application.JOB.Modals.Auth;
using Application.JOB.Modals.Common;
using Microsoft.AspNetCore.Mvc;

namespace JOB_Portal.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(ITokenService tokenService) : ControllerBase
    {
        private readonly ITokenService _tokenService = tokenService;

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            Result<LoginResponse> result = await _tokenService.LoginAsync(request);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register() { return Ok(); }
    }
}
