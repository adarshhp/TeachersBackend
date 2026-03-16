using MyWebApi.Models;
using MyWebApi.Models.DTOs;

namespace MyWebApi.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(RegisterRequest request);
        Task<AuthResponse> LoginAsync(LoginRequest request);
        Task<User?> GetUserByEmailAsync(string email);
    }
}
