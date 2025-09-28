using EventNews.API.Abstractions;
using EventNews.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EventNews.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            var result = await _authService.Register(dto);
            if (result.IsSuccess == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        /// <summary>
        /// it will send one-time-pass to user's email and you need to very it to get token
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var result = await _authService.Login(dto);

            if (result.IsSuccess == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp(string email, int otp)
        {
            var result = await _authService.VerifyOtp(email, otp);
            if(result == null)
            {
                return BadRequest("Error while confirming otp");
            }
            if (string.IsNullOrEmpty(result.Token))
            {
                return BadRequest("Error while generating token");
            }

            return Ok(result);
        }
    }
}
