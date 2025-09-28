using EventNews.API.Models.Enums;
using System;
using System.Web;

namespace EventNews.API.Models.Entities
{
    public class User
    {
        public long Id { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }


        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
        public EUserRoles Role { get; set; } = EUserRoles.User;
        public EItemStates State { get; set; } = EItemStates.Active;
    }
}
