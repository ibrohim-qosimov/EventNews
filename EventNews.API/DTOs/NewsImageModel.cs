using EventNews.API.Models.Enums;
using System;

namespace EventNews.API.DTOs
{
    public class NewsImageModel
    {
        public Guid Id { get; set; }
        public Guid FileId { get; set; }
        public string Url { get; set; }
        public EImageType Type { get; set; }
    }
}
