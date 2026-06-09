using EventNews.API.Models.Enums;
using EventNews.API.Models.Languages;
using System;

namespace EventNews.API.Models.Entities
{
    public class Organization : ILocalizedTitles, ILanguageContents
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
        public EOrganizationType Type { get; set; }

        public string? Address { get; set; }
        public string? Country { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        public Guid? LogoId { get; set; }
        public FileEntity? Logo { get; set; }

        public long SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }

        public EItemStates State { get; set; } = EItemStates.Active;
    }
}
