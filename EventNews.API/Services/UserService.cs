using EventNews.API.Abstractions;
using EventNews.API.Converters;
using EventNews.API.DTOs;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventNews.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            var users = await _userRepository.GetUsers(x => x.Role == Models.Enums.EUserRoles.User);
            return users.Select(x=>x.ToDto());
        }

        public async Task<UserModel> GetUserById(long id)
        {
            var user = await _userRepository.GetUserById(id);
            return user.ToDto();
        }

        public async Task<IEnumerable<UserModel>> GetUsersAll()
        {
            var users = await _userRepository.GetUsers(x=>x.Id > 0);
            return users.Select(x => x.ToDto());
        }
    }
}
