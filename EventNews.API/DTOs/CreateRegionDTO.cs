namespace EventNews.API.DTOs
{
    public class CreateRegionDTO
    {
        public string TitleUz { get; set; }
        public string TitleRu { get; set; }
        public string TitleEn { get; set; }
        public string TitleCrlyc { get; set; }
        public int ParentId { get; set; }
    }
}
