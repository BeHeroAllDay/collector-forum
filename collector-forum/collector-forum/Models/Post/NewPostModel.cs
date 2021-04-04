using System;

namespace collector_forum.Models.Post
{
    public class NewPostModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImageUrl { get; set; }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }


        public DateTime Created { get; set; }
        public string AuthorName { get; set; }



    }
}
