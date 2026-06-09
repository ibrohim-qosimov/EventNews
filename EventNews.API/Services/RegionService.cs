using EventNews.API.Abstractions;
using EventNews.API.Converters;
using EventNews.API.DTOs;
using EventNews.API.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventNews.API.Services
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;

        public RegionService(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task<IEnumerable<RegionModel>> GetAllRegions()
        {
            var results = await _regionRepository.GetAllAsync();
            return results.Select(r => r.ToModel());
        }

        public async Task<RegionModel> GetRegionById(long id)
        {
            var result = await _regionRepository.GetByIdAsync(id);
            var children = (await _regionRepository.GetChildrenAsync(id))?.Select(c => c.ToModel(null)).ToList();

            return result?.ToModel(children);
        }

        public async Task<RegionModel> AddRegion(CreateRegionDTO dto)
        {
            var entity = dto.ToEntity();
            var result = await _regionRepository.AddAsync(entity);
            return result.ToModel();
        }

        public async Task<RegionModel> UpdateRegion(UpdateRegionDTO dto)
        {
            var entity = await _regionRepository.GetByIdAsync(dto.Id);
            if (entity == null) return null;

            entity.TitleUz = dto.TitleUz;
            entity.TitleRu = dto.TitleRu;
            entity.TitleEn = dto.TitleEn;
            entity.TitleCrlyc = dto.TitleCrlyc;
            entity.ParentId = dto.ParentId;

            var result = _regionRepository.Update(entity);
            return result.ToModel();
        }

        public bool DeleteRegion(long id)
        {
            return _regionRepository.Delete(id);
        }
    }
}
