using EventNews.API.Models.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventNews.API.Abstractions
{
    public interface INewsImagesService
    {
        Task<bool> AddImagesToSingleNews(IEnumerable<IFormFile> files, long newsId);
        Task<NewsImage> AddImage(NewsImage image);

        Task<NewsImage> UpdateImage(NewsImage image);

        Task<NewsImage> UpdateImage(Func<NewsImage> update, Guid id);
        Task<IEnumerable<NewsImage>> GetImagesByNewsId(long newsId);

        Task<NewsImage> GetImageById(Guid id);
    }
}
