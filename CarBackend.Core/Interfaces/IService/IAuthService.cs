using CarBackend.Core.Models.DTOs;

namespace CarBackend.Core.Interfaces.IService
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterDto model);
        Task<AuthResponseDto> LoginAsync(LoginDto model);
    }
}
