using FreshVegCart.API.Data;
using FreshVegCart.API.Data.Entities;
using FreshVegCart.API.Services.Interfaces;
using FreshVegCart.Shared.Dto;
using FreshVegCart.Shared.SeedWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FreshVegCart.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IConfiguration _configuration;

        public AuthService(ApplicationDbContext context, IPasswordHasher<User> passwordHasher, IConfiguration configuration)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
        }

        public async Task<ApiResult<LoggedInUser>> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(i => i.Email == dto.Username);
            if (user is null)
                return ApiResult<LoggedInUser>.Failure("Invalid username or password");

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if(result != PasswordVerificationResult.Success)
                return ApiResult<LoggedInUser>.Failure("Invalid username or password");

            // Generate jwt
            var jwt = GenerateString(user);
            var loggedInUser = new LoggedInUser(user.Id, user.Name, user.Email, jwt);
            return ApiResult<LoggedInUser>.Success(loggedInUser);
        }

        public async Task<ApiResult> RegisterUser(RegisterDto dto)
        {
            if (await _context.Users.AnyAsync(i => i.Email == dto.Email))
            {
                return ApiResult.Failure("Email already exists");
            }

            var user = new User()
            {
                Name = dto.Name,
                Email = dto.Email,
                Mobile = dto.Mobile
            };
            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return ApiResult.Success();
            }
            catch (Exception ex)
            {
                return ApiResult.Failure(ex.Message);
            }
        }

        private string GenerateString(User user)
        {
            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var secretKey = _configuration.GetValue<string>("Jwt:SecretKey");
            var securityKey = Encoding.UTF8.GetBytes(secretKey);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(securityKey), SecurityAlgorithms.HmacSha256);
            var expireInMinutes = _configuration.GetValue<int>("Jwt:ExpireInMinutes");

            var token = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("Jwt:Issuer"),
                audience: _configuration.GetValue<string>("Jwt:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expireInMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
