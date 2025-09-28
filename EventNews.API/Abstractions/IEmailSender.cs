using EventNews.API.DTOs;
using System.Threading.Tasks;

namespace EventNews.API.Abstractions
{
    public interface IEmailSender
    {
        Task<BaseResponse> SendMessageAsync(string email, int message);
    }
}
