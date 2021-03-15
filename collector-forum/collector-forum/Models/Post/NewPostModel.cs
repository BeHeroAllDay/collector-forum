namespace collector_forum.Models.Post
{
    public class NewPostModel
    {
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public string AuthorName { get; set; }
        public string CategoryImageUrl { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
