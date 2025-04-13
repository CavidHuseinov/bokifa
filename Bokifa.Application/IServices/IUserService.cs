using Bokifa.Domain.DTOs.Favorite;
using Bookifa.Domain.DTOs.User;

namespace Bookifa.Application.IService
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
        Task LogOutAsync();
    }
}
