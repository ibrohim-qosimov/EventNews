using EventNews.API.Abstractions;
using EventNews.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventNews.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly IApplicationDbContext _context;

        public RegionRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public Region Add(Region region)
        {
            var result = _context.Regions.Add(region);
            _context.SaveChanges();
            return result.Entity;
        }

        public async Task<Region> AddAsync(Region region)
        {
            var result = await _context.Regions.AddAsync(region);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public bool Delete(long id)
        {
            var region = _context.Regions.FirstOrDefault(r => r.Id == id);
            if (region == null) return false;

            _context.Regions.Remove(region);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Region> GetAll()
        {
            return _context.Regions.ToList();
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _context.Regions.ToListAsync();
        }

        public Region GetById(long id)
        {
            return _context.Regions.FirstOrDefault(r => r.Id == id);
        }

        public async Task<Region> GetByIdAsync(long id)
        {
            return await _context.Regions.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<Region>> GetChildrenAsync(long parentId)
        {
            return await _context.Regions.Where(r => r.ParentId == parentId).ToListAsync();
        }

        public Region Update(Region region)
        {
            var result = _context.Regions.Update(region);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
