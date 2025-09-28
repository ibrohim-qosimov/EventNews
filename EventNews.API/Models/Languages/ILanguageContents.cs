using Microsoft.JSInterop;
using System.Security.Policy;

namespace EventNews.API.Models.Languages
{
    public interface ILanguageContents
    {
        public string ContentUz { get; set; }
        public string ContentRu { get; set; }
        public string ContentEn { get; set; }
        public string ContentCrlyc { get; set; }
    }
}
