using EventNews.API.Abstractions;
using EventNews.API.Models.Entities;
using EventNews.API.Models.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventNews.API.Services
{
    public class NewsImagesService : INewsImagesService
    {
        private readonly INewsImagesRepository _newsImagesRepository;
        private readonly IFileService _fileService;
        public NewsImagesService(INewsImagesRepository newsImagesRepository, IFileService fileService)
        {
            _newsImagesRepository = newsImagesRepository;
            _fileService = fileService;
        }

        public async Task<bool> AddImagesToSingleNews(IEnumerable<IFormFile> files, long newsId)
        {
            try
            {
                foreach (var file in files)
                {
                    var savedFileId = await _fileService.SaveFileAsync(file);

                    var newsImage = new NewsImage
                    {
                        NewsId = newsId,
                        FileId = savedFileId,
                        Type = EImageType.Original,
                    };

                    await _newsImagesRepository.Add(newsImage);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<NewsImage> AddImage(NewsImage image)
            => await _newsImagesRepository.Add(image);

        public async Task<NewsImage> UpdateImage(NewsImage image)
            => await _newsImagesRepository.Update(image);
        
        public async Task<NewsImage> UpdateImage(Func<NewsImage> update, Guid id)
        {
            var existingImage = await _newsImagesRepository.GetImageById(id);

            if (existingImage == null)
                return null;

            update();
            
            return await _newsImagesRepository.Update(existingImage);
        }

        public async Task<IEnumerable<NewsImage>> GetImagesByNewsId(long newsId)
            => await _newsImagesRepository.GetImages(x => x.NewsId == newsId);

        public async Task<NewsImage> GetImageById(Guid id)
            => await _newsImagesRepository.GetImageById(id);
        
    }
}
