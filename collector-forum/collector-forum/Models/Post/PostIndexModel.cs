using collector_forum.Models.Reply;
using System;
using System.Collections.Generic;

namespace collector_forum.Models.Post
{
    public class PostIndexModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int AuthorRating { get; set; }
        public DateTime Created { get; set; }
        public bool IsAuthorAdmin { get; set; }
        public bool IsAuthorMod { get; set; }
        public string PostContent { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public IEnumerable<PostReplyModel> Replies { get; set; }
    }
}
