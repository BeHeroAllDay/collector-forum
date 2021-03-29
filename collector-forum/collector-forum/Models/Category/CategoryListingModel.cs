using collector_forum.Models.Post;
using System.Collections.Generic;

namespace collector_forum.Models.Category
{
    public class CategoryListingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public int NumberOfPosts { get; set; }
        public int NumberOfUsers { get; set; }

        public bool HasRecentPost { get; set; }
    }
}
