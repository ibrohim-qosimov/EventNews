using EventNews.API.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventNews.API.Abstractions
{
    public interface IRegionRepository
    {
        IEnumerable<Region> GetAll();
        Task<IEnumerable<Region>> GetAllAsync();
        Region GetById(long id);
        Task<Region> GetByIdAsync(long id);
        Task<List<Region>> GetChildrenAsync(long parentId);
        Region Add(Region region);
        Task<Region> AddAsync(Region region);
        Region Update(Region region);
        bool Delete(long id);
    }
}
