using collector_forum.Data;
using collector_forum.Data.Models;
using collector_forum.Models.Reply;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ApplicationDbContext _context;

        public ReplyController(ICategory categoryService,
            IPost postService,
            UserManager<ApplicationUser> userManager,
            IApplicationUser userService,
            ApplicationDbContext context)
        {
            _postService = postService;
            _userManager = userManager;
            _userService = userService;
            _categoryService = categoryService;
            _context = context;
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


        public IActionResult Delete(int id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            if (userId == null)
            {
                return View("AccessDenied");
            }

            var reply = _context.PostReplies.Find(id);

            if (reply == null)
            {
                ViewBag.ErrorMessage = $"Reply with ID = {reply} cannot be found";
                return View("NotFound");
            }

            _context.Remove(reply);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            _context.PostReplies.Find(id);
            _context.Remove(id);

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            if (userId == null)
            {
                return View("AccessDenied");
            }

            var rep = _context.PostReplies.Find(id);

            if (rep == null)
            {
                ViewBag.ErrorMessage = $"Reply with ID = {rep} cannot be found";
                return View("NotFound");
            }

            if (userId == rep.User.Id || User.IsInRole("Admin") || User.IsInRole("Mod"))
            {
                return View(rep);
            }
            else
            {
                return View("NotFound");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind(include: "Id, Content, Created, Updated")] PostReply reply)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(reply).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Manage");
            }
            return View(reply);
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
