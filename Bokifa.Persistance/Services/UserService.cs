using Bokifa.Domain.DTOs.AppUserAndPromocode;
using Bokifa.Domain.DTOs.Book;
using Bokifa.Domain.DTOs.EmailQueueDto;
using Bokifa.Domain.DTOs.Favorite;
using Bokifa.Domain.DTOs.Promocode;
using Bookifa.Domain.DTOs.User;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Bookifa.Persistance.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        private readonly IEmailService _emailService;
        private readonly IMemoryCache _memoryCache;
        private HttpResponse Response => _httpContextAccessor.HttpContext!.Response;

        public UserService(IMapper mapper,
                           UserManager<AppUser> userManager,
                           IHttpContextAccessor httpContextAccessor,
                           IConfiguration config,
                           IEmailService emailService,
                           IMemoryCache memoryCache)
        {
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _config = config;
            _emailService = emailService;
            _memoryCache = memoryCache;
        }

        private string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }

        private string GenerateAccessToken(AppUser user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
               issuer: _config["JWT:Issuer"],
               audience: _config["JWT:Audience"],
               claims: claims,
               expires: DateTime.UtcNow.AddMinutes(20),
               signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<ICollection<UserDto>> GetAllAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return _mapper.Map<ICollection<UserDto>>(users);
        }

        public async Task<UserDto> GetByidAsync()
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                throw new InvalidOperationException("User not found");

            var user = await _userManager.Users
                .Where(x => x.Id == userId)
                .Select(x => new UserDto
                {
                    Id = x.Id,
                    Username = x.UserName,
                    Name = x.Name,
                    Surname = x.Surname,
                    Email = x.Email,
                    Favorites = x.Favorites.Select(f => new FavoriteDto
                    {
                        BookId = f.BookId,
                        Book = new BookMiniDto
                        {
                            Title = f.Book.Title,
                            Description = f.Book.Description,
                            ImgUrl = f.Book.ImgUrl,
                            Price = f.Book.Price,
                            Discount = f.Book.Discount,
                        }
                    }).ToList(),
                    AppUserAndPromocodes = x.AppUserAndPromocodes.Select(up => new AppUserAndPromocodeDto
                    {
                        PromocodeId = up.PromocodeId,
                        Promocode = new PromocodeDto
                        {
                            Code = up.Promocode.Code,
                            Discount = up.Promocode.Discount,
                            ExpirationDate = up.Promocode.ExpirationDate.ToString("yyyy-MM-dd"),
                            IsUsed = up.Promocode.IsUsed,
                            CreatedAt = up.Promocode.CreatedAt.Date.ToString("yyyy-MM-dd"),
                        }
                    }).ToList()
                }).FirstOrDefaultAsync();

            if (user == null)
                throw new InvalidOperationException("User not found");

            return user;
        }



        public async Task RegisterAsync(RegisterDto registerDto)
        {
            if (await _userManager.FindByNameAsync(registerDto.Username) != null)
                throw new InvalidOperationException("This username already exists.");

            if (await _userManager.FindByEmailAsync(registerDto.Email) != null)
                throw new InvalidOperationException("This email already exists.");

            var user = _mapper.Map<AppUser>(registerDto);
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    sb.AppendLine(error.Description);
                }
                throw new InvalidOperationException(sb.ToString());
            }
            await _userManager.UpdateAsync(user);
        }

        public async Task<TokenDto> LoginAsync(LoginDto loginDto)
        {
            AppUser? user = await _userManager.FindByEmailAsync(loginDto.UsernameOrEmail) ??
                            await _userManager.FindByNameAsync(loginDto.UsernameOrEmail);

            if (user == null) throw new InvalidOperationException("User not found");

            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!result) throw new InvalidOperationException("Username or password incorrect");

            var roles = await _userManager.GetRolesAsync(user);
            var accessToken = GenerateAccessToken(user, roles);

            var refreshToken = GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.ExpirationRefreshTokenDate = DateTime.UtcNow.AddDays(7);
            await _userManager.UpdateAsync(user);

            Response.Cookies.Append("RefreshToken", refreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddDays(7),
            });


            _memoryCache.Set(refreshToken, user, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.UtcNow.AddDays(7),
                Priority = CacheItemPriority.Normal
            });

            return new TokenDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        public async Task ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
            if (user == null)
                throw new InvalidOperationException("No account found for this email address");

            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            string encodedToken = WebUtility.UrlEncode(resetToken);
            string resetUrl = $"{_config["Frontend:BaseUrl"]}/reset-password?email={forgotPasswordDto.Email}&token={encodedToken}";
            var emailDto = new EmailQueueDto
            {
                ToEmails = new List<string> { forgotPasswordDto.Email },
                Subject = "Reset Your Password",
                Body = $"To reset your password, please <a href='{resetUrl}'>click here</a>",
            };

            await _emailService.SendEmailsAsync(emailDto);
        }

        public async Task ResetPasswordAsync(ResetPasswordDto resetPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
            if (user == null)
                throw new InvalidOperationException("User not found");

            string decodedToken = WebUtility.UrlDecode(resetPasswordDto.Token);
            var result = await _userManager.ResetPasswordAsync(user, decodedToken, resetPasswordDto.NewPassword);
            if (!result.Succeeded)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    sb.AppendLine(error.Description);
                }
                throw new ArgumentException("Password reset unsuccessful.");
            }
        }

        public async Task<TokenDto> RefreshToken(string refreshToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) throw new InvalidOperationException("User not found");

            var user = await GetUserFromRefreshToken(refreshToken);
            if (user == null || (DateTime.UtcNow - user.ExpirationRefreshTokenDate).TotalDays > 7)
            {
                throw new InvalidDataException("Invalid or expired refresh token");
            }

            var oldAccessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"]
                .ToString().Replace("Bearer ", "");
            if (!string.IsNullOrEmpty(oldAccessToken))
            {
                _memoryCache.Remove(oldAccessToken);
            }

            var roles = await _userManager.GetRolesAsync(user);
            var newAccessToken = GenerateAccessToken(user, roles);

            if (user.ExpirationRefreshTokenDate < DateTime.UtcNow)
            {
                var newRefreshToken = GenerateRefreshToken();
                user.RefreshToken = newRefreshToken;
                user.ExpirationRefreshTokenDate = DateTime.UtcNow.AddDays(7);

                Response.Cookies.Append("RefreshToken", newRefreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddDays(7),
                });

                refreshToken = newRefreshToken;
            }

            await _userManager.UpdateAsync(user);

            _memoryCache.Set(refreshToken, user, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.UtcNow.AddDays(7),
                Priority = CacheItemPriority.Normal
            });

            return new TokenDto
            {
                AccessToken = newAccessToken,
                RefreshToken = refreshToken
            };
        }
        private async Task<AppUser> GetUserFromRefreshToken(string refreshToken)
        {
            return await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
        }
        public async Task LogOutAsync()
        {
            var accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"]
        .ToString().Replace("Bearer ", "");

            _memoryCache.Remove(accessToken);

            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(userId))
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    user.RefreshToken = null;
                    await _userManager.UpdateAsync(user);
                }
            }

            _httpContextAccessor.HttpContext.Response.Cookies.Delete("RefreshToken");
        }
    }
}
