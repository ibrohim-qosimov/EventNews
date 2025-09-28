using EventNews.API.Abstractions;
using EventNews.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EventNews.API.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly IApplicationDbContext _context;
        public NewsRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public News Add(News news)
        {
            var result = _context.News.Add(news);
            _context.SaveChanges();
            return result.Entity;
        }

        public async Task<News> AddAsync(News news)
        {
            var result = await _context.News.AddAsync(news);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public bool Delete(long id)
        {
            var result = _context.News.FirstOrDefault(n => n.Id == id);
            if (result == null) return false;
            result.State = Models.Enums.EItemStates.Deleted;
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<News> GetAll()
        {
            return _context.News.ToList();
        }

        public async Task<IEnumerable<News>> GetAllAsync()
        {
            return await _context.News.ToListAsync();
        }

        public News GetById(long id)
        {
            return _context.News.FirstOrDefault(n => n.Id == id);
        }

        public async Task<News> GetByIdAsync(long id)
        {
            return await _context.News.FirstOrDefaultAsync(n => n.Id == id);
        }

        public News Update(News news)
        {
            return _context.News.Update(news).Entity;
        }
    }
}
