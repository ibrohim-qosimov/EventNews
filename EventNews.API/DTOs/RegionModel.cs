using System.Collections.Generic;

namespace EventNews.API.DTOs
{
    public class RegionModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ParentId { get; set; }
        public List<RegionModel> Children { get; set; } = new List<RegionModel>();
    }
}
