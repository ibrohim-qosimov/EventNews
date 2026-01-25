using EventNews.API.Abstractions;
using EventNews.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EventNews.API.Repositories
{
    public class NewsImagesRepository : INewsImagesRepository
    {

        private readonly IApplicationDbContext _context;

        public NewsImagesRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<NewsImage> Add(NewsImage image)
        {
            var result = await _context.NewsImages.AddAsync(image);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<NewsImage> Update(NewsImage image)
        {
            var result = _context.NewsImages.Update(image);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<NewsImage>> GetImages(Expression<Func<NewsImage, bool>> expression)
        {
            return _context.NewsImages.Where(expression);
        }

        public async Task<NewsImage> GetImageById(Guid id)
        {
            return await _context.NewsImages.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}