using EventNews.API.Models.Enums;
using EventNews.API.Models.Languages;
using System;
using System.Collections;
using System.Collections.Generic;

namespace EventNews.API.Models.Entities
{
    public class News : ILocalizedTitles, ILanguageContents, ILanguageShortContent
    {
        public long Id { get; set; }

        public string TitleUz { get; set; }
        public string TitleRu { get; set; }
        public string TitleEn { get; set; }
        public string TitleCrlyc { get; set; }

        public string ContentUz { get; set; }
        public string ContentRu { get; set; }
        public string ContentEn { get; set; }
        public string ContentCrlyc { get; set; }

        public string ShortContentUz { get; set; }
        public string ShortContentRu { get; set; }
        public string ShortContentEn { get; set; }
        public string ShortContentCrlyc { get; set; }

        public DateTimeOffset PublishedAt { get; set; } = DateTimeOffset.UtcNow;
        public EItemStates State { get; set; } = EItemStates.Active;

        public virtual ICollection<NewsImage> Files { get; set; } = new List<NewsImage>();
    }
}
