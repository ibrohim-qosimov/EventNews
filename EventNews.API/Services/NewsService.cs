using EventNews.API.Abstractions;
using EventNews.API.Converters;
using EventNews.API.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventNews.API.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;

        public NewsService(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<NewsModel> AddNews(CreateNews dto)
        { 
            var model = dto.ToEntity();
            var result = await _newsRepository.AddAsync(model);
            return result.ToModel();
        }

        public async Task<NewsModel> UpdateNews(UpdateNews dto)
        {
            var existingNews = await _newsRepository.GetByIdAsync(dto.Id);

            if (existingNews == null) return null;

            existingNews.TitleUz = dto.TitleUz;
            existingNews.ShortContentUz = dto.ShortContentUz;
            existingNews.ContentUz = dto.ContentUz;

            existingNews.TitleRu = dto.TitleRu;
            existingNews.ShortContentRu = dto.ShortContentRu;
            existingNews.ContentRu = dto.ContentRu;

            existingNews.TitleEn = dto.TitleEn;
            existingNews.ShortContentEn = dto.ShortContentEn;
            existingNews.ContentEn = dto.ContentEn;

            existingNews.TitleCrlyc = dto.TitleCrlyc;
            existingNews.ShortContentCrlyc = dto.ShortContentCrlyc;
            existingNews.ContentCrlyc = dto.ContentCrlyc;

            existingNews.ImageUrl = dto.ImageUrl;

            var result = _newsRepository.Update(existingNews);

            return result.ToModel();
        }

        public async Task<NewsModel> GetNewsById(long id)
        {
            var result = await _newsRepository.GetByIdAsync(id);
            return result?.ToModel();
        }

        public async Task<IEnumerable<NewsModel>> GetAllNews()
        {
            var results = await _newsRepository.GetAllAsync();
            return results.Select(n => n.ToModel());
        }

        public bool DeleteNews(long id)
        {
            return _newsRepository.Delete(id);
        }
    }
}
