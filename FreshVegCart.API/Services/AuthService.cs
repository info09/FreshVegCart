using FreshVegCart.API.Data;
using FreshVegCart.API.Data.Entities;
using FreshVegCart.API.Services.Interfaces;
using FreshVegCart.Shared.Dto;
using FreshVegCart.Shared.SeedWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FreshVegCart.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthService(ApplicationDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
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
            var jwt = "JWT_TOKEN";
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
    }
}
