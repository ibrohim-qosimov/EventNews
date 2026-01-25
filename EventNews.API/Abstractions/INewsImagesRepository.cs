using EventNews.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EventNews.API.Abstractions
{
    public interface INewsImagesRepository
    {
        Task<NewsImage> Add(NewsImage image);
        Task<NewsImage> Update(NewsImage image);
        Task<IEnumerable<NewsImage>> GetImages(Expression<Func<NewsImage, bool>> expression);
        Task<NewsImage> GetImageById(Guid id);

    }
}
