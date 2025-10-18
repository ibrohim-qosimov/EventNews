using EventNews.API.DTOs;
using EventNews.API.Models.Entities;
using EventNews.API.Repositories;
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
        Task<News> GetNewByIdAdmin(long id);
        Task<IEnumerable<NewsModel>> GetAllNews();
        Task<IEnumerable<News>> GetAllNewsAdmin();
        bool DeleteNews(long id);
    }
}
