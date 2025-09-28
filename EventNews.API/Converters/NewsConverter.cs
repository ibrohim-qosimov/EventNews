using EventNews.API.DTOs;
using EventNews.API.Models.Entities;
using EventNews.API.Models.Languages;

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
            ImageUrl = entity.ImageUrl
        };

        public static News ToEntity(this CreateNews dto) => new News
        {
            ImageUrl = dto.ImageUrl,

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
