using EventNews.API.DTOs;
using EventNews.API.Models.Entities;
using System.Security.Policy;

namespace EventNews.API.Converters
{
    public static class UsersConverter
    {
        public static UserModel ToDto(this User user)
        {
            if (user == null) return null;

            return new UserModel
            {
                Id = user.Id,
                Email = user.Email,
            };
        }
    }
}
