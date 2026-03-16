using MyWebApi.Models;
using MyWebApi.Models.DTOs;
using MyWebApi.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace MyWebApi.Services.Impl
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<User> _userRepository;

        public AuthService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            // Check if user already exists
            var existingUsers = await _userRepository.FindAsync(u => u.Email == request.Email);
            if (existingUsers.Any())
            {
                return new AuthResponse
                {
                    Message = "User with this email already exists"
                };
            }

            // Create new user
            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = HashPassword(request.Password),
                CreatedAt = DateTime.UtcNow
            };

            var createdUser = await _userRepository.AddAsync(user);

            return new AuthResponse
            {
                UserId = createdUser.Id,
                Name = createdUser.Name,
                Email = createdUser.Email,
                Token = GenerateToken(createdUser),
                Message = "Registration successful"
            };
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            // Find user by email
            var users = await _userRepository.FindAsync(u => u.Email == request.Email);
            var user = users.FirstOrDefault();

            if (user == null)
            {
                return new AuthResponse
                {
                    Message = "Invalid email or password"
                };
            }

            // Verify password
            if (!VerifyPassword(request.Password, user.PasswordHash))
            {
                return new AuthResponse
                {
                    Message = "Invalid email or password"
                };
            }

            return new AuthResponse
            {
                UserId = user.Id,
                Name = user.Name,
                Email = user.Email,
                Token = GenerateToken(user),
                Message = "Login successful"
            };
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            var users = await _userRepository.FindAsync(u => u.Email == email);
            return users.FirstOrDefault();
        }

        // Simple password hashing using SHA256 (for production, use bcrypt or AspNetCore Identity)
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        private bool VerifyPassword(string password, string hash)
        {
            var hashOfInput = HashPassword(password);
            return hashOfInput == hash;
        }

        // Simple token generation (for production, use JWT tokens)
        private string GenerateToken(User user)
        {
            var tokenData = $"{user.Id}:{user.Email}:{DateTime.UtcNow.Ticks}";
            var bytes = Encoding.UTF8.GetBytes(tokenData);
            return Convert.ToBase64String(bytes);
        }
    }
}
