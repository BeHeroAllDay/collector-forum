using collector_forum.Models.Post;
using System.Collections.Generic;

namespace collector_forum.Models.Search
{
    public class SearchResultModel
    {
        public IEnumerable<PostListingModel> Posts { get; set; }
        public string SearchQuery { get; set; }
        public bool EmptySearchResults { get; set; }
    }
}
