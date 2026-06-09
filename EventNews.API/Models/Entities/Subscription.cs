using EventNews.API.Models.Enums;
using EventNews.API.Models.Languages;

namespace EventNews.API.Models.Entities
{
    public class Subscription : ILanguageContents
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ESubscriptionType Type { get; set; }
        public string ContentUz { get ; set ; }
        public string ContentRu { get ; set ; }
        public string ContentEn { get ; set ; }
        public string ContentCrlyc { get ; set ; }
        public int Duration { get; set; }
        public decimal Price { get; set; } = 0;

        public EItemStates State { get; set; } = EItemStates.Active;

    }
}
