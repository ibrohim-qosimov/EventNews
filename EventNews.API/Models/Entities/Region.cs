using EventNews.API.Models.Languages;

namespace EventNews.API.Models.Entities
{
    public class Region : ILocalizedTitles
    {
        public int Id { get; set; }
        public string TitleUz { get; set; }
        public string TitleRu { get; set; }
        public string TitleEn { get; set; }
        public string TitleCrlyc { get; set; }

        public int ParentId { get; set; }
        public Region Parent { get; set; }
    }
}
