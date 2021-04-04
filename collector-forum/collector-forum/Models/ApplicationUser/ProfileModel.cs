using System;

namespace collector_forum.Models.ApplicationUser
{
    public class ProfileModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string UserRating { get; set; }


        public bool IsAdmin { get; set; }
        public bool IsMod { get; set; }


        public DateTime MemberSince { get; set; }
    }
}
