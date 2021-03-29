using collector_forum.Data;
using collector_forum.Data.Models;
using collector_forum.Models.Category;
using collector_forum.Models.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collector_forum.Controllers
{
    public class ForumController : Controller
    {
        private readonly ICategory _categoryService;
        private readonly IPost _postService;

        public ForumController(ICategory categoryService, IPost postService)
        {
            _categoryService = categoryService;
            _postService = postService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetAll()
                .Select(category => new CategoryListingModel
                {
                    Id = category.Id,
                    Name = category.Title,
                    Description = category.Description,
                    NumberOfPosts = category.Posts?.Count() ?? 0,
                    NumberOfUsers = _categoryService.GetActiveUsers(category.Id).Count(),
                    ImageUrl = category.ImageUrl,
                    HasRecentPost = _categoryService.HasRecentPost(category.Id)
                });

            var model = new CategoryIndexModel
            {
                CategoryList = categories.OrderBy(c => c.Name)
            };
             
            return View(model);
        }

        public IActionResult Topic(int id, string searchQuery)
        {
            var category = _categoryService.GetById(id);
            var posts = new List<Post>();

            posts = _postService.GetFilteredPosts(category, searchQuery).ToList();

            var postListings = posts.Select(post => new PostListingModel
            {
                Id = post.Id,
                AuthorId = post.User.Id,
                AuthorRating = post.User.Rating,
                AuthorName = post.User.UserName,
                Title = post.Title,
                DatePosted = post.Created.ToString(),
                RepliesCount = post.Replies.Count(),
                Category = BuildCategoryListing(post)
            });

            var model = new CategoryTopicModel
            {
                Posts = postListings,
                Category = BuildCategoryListing(category)
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Search(int id, string searchQuery)
        {
            return RedirectToAction("Topic", new { id, searchQuery });
        }

        public IActionResult Create()
        {
            var model = new AddCategoryModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryModel model)
        {
            var category = new Category
            {
                Title = model.Title,
                Description = model.Description,
                Created = DateTime.Now
            };

            await _categoryService.Create(category);
            return RedirectToAction("Index", "Forum");
        }


        private CategoryListingModel BuildCategoryListing(Post post)
        {
            var category = post.Category;

            return BuildCategoryListing(category);
        }

        private CategoryListingModel BuildCategoryListing(Category category)
        {
            return new CategoryListingModel
            {
                Id = category.Id,
                Name = category.Title,
                Description = category.Description,
                ImageUrl = category.ImageUrl
            };
        }
    }
}
