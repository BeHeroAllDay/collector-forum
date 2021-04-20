using collector_forum.Data;
using collector_forum.Data.Models;
using collector_forum.Models;
using collector_forum.Models.Category;
using collector_forum.Models.Home;
using collector_forum.Models.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace collector_forum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPost _postService;
        

        public HomeController(ILogger<HomeController> logger, IPost postService)
        {
            _logger = logger;
            _postService = postService;
        }

        public IActionResult Index()
        {
            var model = BuildHomeIndexModel();
            return View(model);
        }

        public IActionResult Rules()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public HomeIndexModel BuildHomeIndexModel()
        {
            var latestPosts = _postService.GetLatestPosts(10);

            var posts = latestPosts.Select(post => new PostListingModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                AuthorRating = post.User.Rating,
                DatePosted = post.Created.ToString(),
                RepliesCount = post.Replies.Count(),
                Category = GetCategoryListingForPost(post)
            });

            return new HomeIndexModel
            {
                LatestPosts = posts,
                SearchQuery = ""
            };
        }

        public CategoryListingModel GetCategoryListingForPost(Post post)
        {
            var category = post.Category;

            return new CategoryListingModel
            {
                Id = category.Id,
                Name = category.Title,
                ImageUrl = category.ImageUrl
            };
        }

        public IActionResult Search(string searchQuery)
        {
            return RedirectToAction("Topic", "Forum", new { searchQuery });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
