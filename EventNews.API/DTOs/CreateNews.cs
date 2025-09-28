using EventNews.API.Models.Languages;

namespace EventNews.API.DTOs
{
    public class CreateNews : ILocalizedTitles, ILanguageContents, ILanguageShortContent
    {
        public string ImageUrl { get; set; }

        public string TitleUz { get; set; }
        public string TitleRu { get; set; }
        public string TitleEn { get; set; }
        public string TitleCrlyc { get; set; }

        public string ContentUz { get; set; }
        public string ContentRu { get; set; }
        public string ContentEn { get; set; }
        public string ContentCrlyc { get; set; }

        public string ShortContentUz { get ; set ; }
        public string ShortContentRu { get ; set ; }
        public string ShortContentEn { get ; set ; }
        public string ShortContentCrlyc { get ; set ; }
    }
}
