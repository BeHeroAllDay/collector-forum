using collector_forum.Data;
using collector_forum.Data.Models;
using collector_forum.Models.Post;
using collector_forum.Models.Reply;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collector_forum.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;
        private readonly ICategory _categoryService;

        private static UserManager<ApplicationUser> _userManager;
        public PostController(IPost postService, ICategory categoryService, UserManager<ApplicationUser> userManager)
        {
            _postService = postService;
            _categoryService = categoryService;
            _userManager = userManager;
        }

        public IActionResult Index(int id)
        {
            var post = _postService.GetById(id);

            var replies = BuildPostReplies(post.Replies);

            var model = new PostIndexModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                AuthorRating = post.User.Rating,
                IsAuthorAdmin = IsAuthorAdmin(post.User),
                IsAuthorMod = IsAuthorMod(post.User),
                Created = post.Created,
                PostContent = post.Content,
                Replies = replies,
                CategoryId = post.Category.Id,
                CategoryName = post.Category.Title
            };

            return View(model);
        }

        public IActionResult Create(int id)
        {
            // Note id is Category.Id
            var category = _categoryService.GetById(id);

            var model = new NewPostModel
            {
                CategoryName = category.Title,
                CategoryId = category.Id,
                CategoryImageUrl = category.ImageUrl,
                AuthorName = User.Identity.Name
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(NewPostModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);
            var post = BuildPost(model, user);

            _postService.Add(post).Wait(); // It should block 

            // TODO: Implement User Rating Management

            return RedirectToAction("Index", "Post", new { id = post.Id });
        }

        private bool IsAuthorAdmin(ApplicationUser user)
        {
            return _userManager.GetRolesAsync(user)
                .Result.Contains("Admin");
        }

        private bool IsAuthorMod(ApplicationUser user)
        {
            return _userManager.GetRolesAsync(user)
                .Result.Contains("Mod");
        }

        private Post BuildPost(NewPostModel model, ApplicationUser user)
        {
            var category = _categoryService.GetById(model.CategoryId);

            return new Post
            {
                Title = model.Title,
                Content = model.Content,
                Created = DateTime.Now,
                User = user,
                Category = category
            };
        }

        private IEnumerable<PostReplyModel> BuildPostReplies(IEnumerable<PostReply> replies)
        {
            return replies.Select(reply => new PostReplyModel
            {
                Id = reply.Id,
                AuthorName = reply.User.UserName,
                AuthorId = reply.User.Id,
                AuthorRating = reply.User.Rating,
                Created = reply.Created,
                ReplyContent = reply.Content,
                IsAuthorAdmin = IsAuthorAdmin(reply.User),
                IsAuthorMod = IsAuthorMod(reply.User)
            });
        }
    }
}
