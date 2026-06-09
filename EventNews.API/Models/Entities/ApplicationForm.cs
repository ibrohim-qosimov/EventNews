using System;
using System.IO;

namespace EventNews.API.Models.Entities
{
    public class ApplicationForm
    {
        public long OrganizationId { get; set; }
        public bool IsAccepted { get; set; }

        public Guid? CheckId { get; set; }
        public FileEntity? Check{ get; set; }
    }
}
