using System;
using System.Collections.Generic;

namespace collector_forum.Data.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Category Category { get; set; }

        public virtual IEnumerable<PostReply> Replies { get; set; }
    }
}
