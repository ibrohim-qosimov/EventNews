using EventNews.API.DTOs;
using EventNews.API.Models.Entities;
using EventNews.API.Models.Languages;
using System.Linq;

namespace EventNews.API.Converters
{
    public static class NewsConverter
    {
        public static NewsModel ToModel(this News entity) => new NewsModel
        {
            Id = entity.Id,
            Title = entity.GetContentByLanguage("uz"),
            Content = entity.GetContentByLanguage("uz"),
            ShortContent = entity.GetShortContentByLanguage("uz"),
            Images = entity.Files?.ToList()
        };

        public static News ToEntity(this CreateNews dto) => new News
        {
            TitleUz = dto.TitleUz,
            ShortContentUz = dto.ShortContentUz,
            ContentUz = dto.ContentUz,

            TitleCrlyc = dto.TitleCrlyc,
            ShortContentCrlyc = dto.ShortContentCrlyc,
            ContentCrlyc = dto.ContentCrlyc,

            TitleRu = dto.TitleRu,
            ShortContentRu = dto.ShortContentRu,
            ContentRu = dto.ContentRu,

            TitleEn = dto.TitleEn,
            ShortContentEn = dto.ShortContentEn,
            ContentEn = dto.ContentEn
        };
    }
}
