using collector_forum.Data;
using collector_forum.Data.Models;
using collector_forum.Models.Category;
using collector_forum.Models.Post;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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
                .Select(categories => new CategoryListingModel
                {
                    Id = categories.Id,
                    Name = categories.Title,
                    Description = categories.Description
                });

            var model = new CategoryIndexModel
            {
                CategoryList = categories
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
                AuthorName = post.User.Nickname,
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
