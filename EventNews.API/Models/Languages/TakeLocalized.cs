using EventNews.API.Models.Entities;

namespace EventNews.API.Models.Languages
{
    public static class TakeLocalized
    {
        public static string GetTitleByLanguage(this News news, string languageCode) => languageCode.ToLower() switch
        {
            "uz" => news.TitleUz,
            "ru" => news.TitleRu,
            "en" => news.TitleEn,
            "crlyc" => news.TitleCrlyc,
            _ => news.TitleUz
        };

        public static string GetContentByLanguage(this News news, string languageCode) => languageCode.ToLower() switch
        {
            "uz" => news.ContentUz,
            "ru" => news.ContentRu,
            "en" => news.ContentEn,
            "crlyc" => news.ContentCrlyc,
            _ => news.ContentUz
        };

        public static string GetShortContentByLanguage(this News news, string languageCode) => languageCode.ToLower() switch
        {
            "uz" => news.ShortContentUz,
            "ru" => news.ShortContentRu,
            "en" => news.ShortContentEn,
            "crlyc" => news.ShortContentCrlyc,
            _ => news.ShortContentUz
        };
    }
}
