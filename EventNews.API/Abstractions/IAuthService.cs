using EventNews.API.DTOs;
using System.Threading.Tasks;

namespace EventNews.API.Abstractions
{
    public interface IAuthService
    {
        Task<TokenResponse> VerifyOtp(string email, int otp);
        Task<BaseResponse> Register(RegisterDTO dto);
        Task<BaseResponse> Login(LoginDTO dto);
    }
}
