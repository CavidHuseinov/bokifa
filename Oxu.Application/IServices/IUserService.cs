using Oxu.Domain.DTOs.User;

namespace Oxu.Application.IService
{
    public interface IUserService
    {
        Task RegisterAsync(RegisterDto registerDto);
        Task<TokenDto> LoginAsync(LoginDto loginDto);
        Task ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto);
        Task ResetPasswordAsync(ResetPasswordDto resetPasswordDto);
        Task<UserDto> GetByidAsync();
        Task<ICollection<UserDto>> GetAllAsync();
        Task<TokenDto> RefreshToken(string refreshToken);
    }
}
