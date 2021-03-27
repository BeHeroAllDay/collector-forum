using System;

namespace collector_forum.Models.Reply
{
    public class PostReplyModel
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int AuthorRating { get; set; }


        public DateTime Created { get; set; }
        public string ReplyContent { get; set; }


        public bool IsAuthorAdmin { get; set; }
        public bool IsAuthorMod { get; set; }


        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }


        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImageUrl { get; set; }
        
    }
}
