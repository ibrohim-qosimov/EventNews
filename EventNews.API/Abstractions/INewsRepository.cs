using EventNews.API.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventNews.API.Abstractions
{
    public interface INewsRepository
    {
        News Add(News news);
        Task<News> AddAsync(News news);
        News Update(News news);
        News GetById(long id);
        Task<News> GetByIdAsync(long id);
        IEnumerable<News> GetAll();
        Task<IEnumerable<News>> GetAllAsync();
        bool Delete(long id);
    }
}
