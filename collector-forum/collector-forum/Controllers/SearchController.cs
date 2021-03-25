using collector_forum.Data;
using collector_forum.Data.Models;
using collector_forum.Models.Category;
using collector_forum.Models.Post;
using collector_forum.Models.Search;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace collector_forum.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPost _postService;

        public SearchController(IPost postService)
        {
            _postService = postService;
        }

        public IActionResult Results(string searchQuery)
         {
            var posts = _postService.GetFilteredPosts(searchQuery);

            var areNoResults =
                (!string.IsNullOrEmpty(searchQuery) && !posts.Any());

            var postListings = posts.Select(post => new PostListingModel
            {
                Id = post.Id,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                AuthorRating = post.User.Rating,
                Title = post.Title,
                DatePosted = post.Created.ToString(),
                RepliesCount = post.Replies.Count(),
                Category = BuildCategoryListing(post)
            });

            var model = new SearchResultModel
            {
                Posts = postListings,
                SearchQuery = searchQuery,
                EmptySearchResults = areNoResults
            };

            return View(model);
        }

        private CategoryListingModel BuildCategoryListing(Post post)
        {
            var category = post.Category;

            return new CategoryListingModel
            {
                Id = category.Id,
                ImageUrl = category.ImageUrl,
                Name = category.Title,
                Description = category.Description
            };
        }

        [HttpPost]
        public IActionResult Search(string searchQuery)
        {
            return RedirectToAction("Results", new { searchQuery });
        }
    }
}
