using EventNews.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventNews.API.Abstractions
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetUsers();
        Task<UserModel> GetUserById(long id);
        Task<IEnumerable<UserModel>> GetUsersAll();
    }
}
