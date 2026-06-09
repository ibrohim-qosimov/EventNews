using EventNews.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventNews.API.Abstractions
{
    public interface IRegionService
    {
        Task<IEnumerable<RegionModel>> GetAllRegions();
        Task<RegionModel> GetRegionById(long id);
        Task<RegionModel> AddRegion(CreateRegionDTO dto);
        Task<RegionModel> UpdateRegion(UpdateRegionDTO dto);
        bool DeleteRegion(long id);
    }
}
