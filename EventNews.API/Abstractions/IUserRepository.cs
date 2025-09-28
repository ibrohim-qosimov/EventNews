using EventNews.API.Models.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EventNews.API.Abstractions
{
    public interface IUserRepository
    {
        Task<User> Add(User user);
        Task<User> Update(User user);
        Task<IEnumerable<User>> GetUsers(Expression<Func<User, bool>> expression);
        Task<User> GetUserById(long id);
    }
}
