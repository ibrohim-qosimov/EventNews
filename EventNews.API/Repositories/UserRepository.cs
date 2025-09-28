using EventNews.API.Abstractions;
using EventNews.API.DTOs;
using EventNews.API.Models.Entities;
using EventNews.API.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Threading.Tasks;

namespace EventNews.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationDbContext _context;

        public UserRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User user)
        {
            var result = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User> Update(User user)
        {
            var result = _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<User>> GetUsers(Expression<Func<User, bool>> expression)
        {
            return _context.Users.Where(expression);
        }

        public async Task<User> GetUserById(long id)
        {
            return await _context.Users.FirstOrDefaultAsync(x=>x.Id == id);
        }
    }
}
