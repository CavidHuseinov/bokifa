using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Bookifa.Application.IService;
using Bookifa.Domain.DTOs.User;
using Bookifa.Presentation.Abstraction;

namespace Bookifa.Presentation.Controllers
{
    public sealed class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var user = await _userService.GetAllAsync();
            return Ok(user);
        }
        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var userProfile = await _userService.GetByidAsync();
            return Ok(userProfile);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterDto dto)
        {
            await _userService.RegisterAsync(dto);
            return Ok();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginDto dto)
        {
            var token = await _userService.LoginAsync(dto);
            return Ok(token);
        }
        [Authorize]
        [HttpGet("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            if (Request.Cookies.TryGetValue("RefreshToken", out string refreshToken))
            {
                var token = await _userService.RefreshToken(refreshToken);
                return Ok(token);
            }

            return BadRequest(new { message = "Refresh token not found" });
        }
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromForm] ForgotPasswordDto dto)
        {
            await _userService.ForgotPasswordAsync(dto);
            return Ok(new { message = "Information has been sent to reset your password. Please check your email inbox." });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync(ResetPasswordDto dto)
        {
            await _userService.ResetPasswordAsync(dto);
            return Ok(new { message = "Your password has been successfully updated." });
        }
        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _userService.LogOutAsync();
            return Ok(new { message = "Logged out successfully" });
        }

    }
}
