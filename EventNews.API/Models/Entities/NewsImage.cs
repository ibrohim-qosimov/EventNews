using EventNews.API.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventNews.API.Models.Entities
{
    [Table("news_images")]
    public class NewsImage
    {
        public Guid Id { get; set; }
        
        public long NewsId { get; set; }
        public Guid FileId { get; set; }
        
        public EImageType Type { get; set; }

        public bool IsVisible { get; set; } = true;
    }
}
