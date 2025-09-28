using EventNews.API.DTOs;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventNews.API.Abstractions
{
    public interface INewsService
    {
        Task<NewsModel> AddNews(CreateNews dto);
        Task<NewsModel> UpdateNews(UpdateNews dto);
        Task<NewsModel> GetNewsById(long id);
        Task<IEnumerable<NewsModel>> GetAllNews();
        bool DeleteNews(long id);
    }
}
