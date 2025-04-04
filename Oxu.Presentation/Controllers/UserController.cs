using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oxu.Application.IService;
using Oxu.Domain.DTOs.User;
using Oxu.Presentation.Abstraction;

namespace Oxu.Presentation.Controllers
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
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromForm] string RefreshToken)
        {
            var token = await _userService.RefreshToken(RefreshToken);
            return Ok(token);
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

    }
}
