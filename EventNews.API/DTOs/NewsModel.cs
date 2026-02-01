using EventNews.API.Models.Entities;
using System.Collections.Generic;

namespace EventNews.API.DTOs
{
    public class NewsModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ShortContent { get; set; }

        public List<NewsImage> Images { get; set; } = new List<NewsImage>();
    }
}
