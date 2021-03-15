using collector_forum.Models.Post;
using System.Collections.Generic;

namespace collector_forum.Models.Home
{
    public class HomeIndexModel
    {
        public string SearchQuery { get; set; }
        public IEnumerable<PostListingModel> LatestPosts { get; set; }
    }
}
