using collector_forum.Data;
using collector_forum.Data.Models;
using collector_forum.Models.Reply;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace collector_forum.Controllers
{
    public class ReplyController : Controller
    {
        private readonly IPost _postService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUser _userService;
        private readonly ICategory _categoryService;

        public ReplyController(ICategory categoryService, IPost postService, UserManager<ApplicationUser> userManager, IApplicationUser userService)
        {
            _postService = postService;
            _userManager = userManager;
            _userService = userService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Create(int id)
        {
            var post = _postService.GetById(id);
            var category = _categoryService.GetById(post.Category.Id);
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var model = new PostReplyModel
            {
                PostContent = post.Content,
                PostTitle = post.Title,
                PostId = post.Id,

                AuthorId = user.Id,
                AuthorName = User.Identity.Name,
                AuthorRating = user.Rating,
                IsAuthorAdmin = User.IsInRole("Admin"),
                IsAuthorMod = User.IsInRole("Mod"),

                CategoryId = post.Category.Id,
                CategoryName = post.Category.Title,
                CategoryImageUrl = post.Category.ImageUrl,

                Date = DateTime.Now
            };

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var post = _postService.GetById(id);

            if (post == null)
            {
                ViewBag.ErrorMessage = $"Post with ID: {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                await _postService.Delete(id);

                return RedirectToAction("Manage");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddReply(PostReplyModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);

            var reply = BuildReply(model, user);

            await _postService.AddReply(reply);

            await _userService.UpdateUserRating(userId, typeof(PostReply));

            return RedirectToAction("Index", "Post", new { id = model.PostId });
        }

        private PostReply BuildReply(PostReplyModel model, ApplicationUser user)
        {
            var post = _postService.GetById(model.PostId);

            return new PostReply
            {
                Post = post,
                Content = model.ReplyContent,
                Created = DateTime.Now,
                User = user
            };
        }
    }
}
