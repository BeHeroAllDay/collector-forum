using collector_forum.Data;
using collector_forum.Data.Models;
using collector_forum.Models.Category;
using collector_forum.Models.Post;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                    Latest = GetLatestPost(category.Id) ?? new PostListingModel(),
                    NumberOfUsers = _categoryService.GetActiveUsers(category.Id).Count(),
                    ImageUrl = category.ImageUrl,
                    HasRecentPost = _categoryService.HasRecentPost(category.Id)
                });

            var categoryListingModel = categories as IList<CategoryListingModel> ?? categories.ToList();

            var model = new CategoryIndexModel
            {
                CategoryList = categoryListingModel.OrderBy(c => c.Name)
            };
             
            return View(model);
        }

        public IActionResult Topic(int id, string searchQuery)
        {
            var category = _categoryService.GetById(id);
            var posts = category.Posts;
            var noResults = (!string.IsNullOrEmpty(searchQuery) && !posts.Any());

            var postListings = posts.Select(post => new PostListingModel
            {
                Id = post.Id,
                Category = BuildCategoryListing(post),
                AuthorId = post.User.Id,
                AuthorRating = post.User.Rating,
                AuthorName = post.User.UserName,
                Title = post.Title,
                DatePosted = post.Created.ToString(CultureInfo.InvariantCulture),
                RepliesCount = post.Replies.Count()
            }).OrderByDescending(post => post.DatePosted);

            var model = new CategoryTopicModel
            {
                EmptySearchResults = noResults,
                Posts = postListings,
                SearchQuery = searchQuery,
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

        [HttpGet]
        public IActionResult Manage()
        {
            var categories = _categoryService.GetAll()
                .Select(c => new CategoryListingModel
                {
                    Id = c.Id,
                    Name = c.Title,
                    Description = c.Description
                });

            return View(categories);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cat = _categoryService.GetById(id);

            if(cat == null)
            {
                ViewBag.ErrorMessage = $"Category with ID: {id} cannot be found";
                return View("NotFound");
            }
            else
            {
               await _categoryService.Delete(id);

                return RedirectToAction("Manage");
            }
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


        public PostListingModel GetLatestPost(int categoryId)
        {
            var post = _categoryService.GetLatestPost(categoryId);

            if (post != null)
            {
                return new PostListingModel
                {
                    AuthorName = post.User != null ? post.User.UserName : "",
                    DatePosted = post.Created.ToString(CultureInfo.InvariantCulture),
                    Title = post.Title ?? ""
                };
            }

            return new PostListingModel();
        }

        private static CategoryListingModel BuildCategoryListing(Category category)
        {
            return new CategoryListingModel
            {
                Id = category.Id,
                Name = category.Title,
                Description = category.Description,
                ImageUrl = category.ImageUrl
            };
        }

        private static CategoryListingModel BuildCategoryListing(Post post)
        {
            var category = post.Category;

            return BuildCategoryListing(category);
        }

        
    }
}
