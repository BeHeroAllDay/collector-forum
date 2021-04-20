using collector_forum.Data;
using collector_forum.Data.Models;
using collector_forum.Models.Post;
using collector_forum.Models.Reply;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace collector_forum.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;
        private readonly ICategory _categoryService;
        private readonly IApplicationUser _userService;
        private readonly ApplicationDbContext _context;

        private static UserManager<ApplicationUser> _userManager;

        public PostController(
            IPost postService,
            ICategory categoryService,
            UserManager<ApplicationUser> userManager,
            IApplicationUser userService,
            ApplicationDbContext context)
        {
            _postService = postService;
            _categoryService = categoryService;
            _userManager = userManager;
            _userService = userService;
            _context = context;
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
                AuthorName = User.Identity.Name,
                CategoryImageUrl = category.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(NewPostModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);
            var post = BuildPost(model, user);

            await _postService.Add(post);
            await _userService.UpdateUserRating(userId, typeof(Post));

            return RedirectToAction("Topic", "Forum", new { id = model.CategoryId });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var post = _postService.GetById(id);

            var reply = post.Replies.Where(x => x.Post.Id == post.Id);

            if (post == null)
            {
                ViewBag.ErrorMessage = $"Post with ID = {post} cannot be found";
                return View("NotFound");
            }

            _context.RemoveRange(reply);

            await _postService.Delete(id);

            return RedirectToAction("Topic", "Forum", new { id = post.Category.Id });

        }


        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            var post = _postService.GetById(id);
            _postService.Delete(id);

            return RedirectToAction("Index", "Forum", new { id = post.Category.Id });
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit(int postId)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            if (userId == null)
            {
                return View("AccessDenied");
            }

            var id = _postService.GetById(postId);

            if (id == null)
            {
                ViewBag.ErrorMessage = $"Post with ID = {postId} cannot be found";
                return View("NotFound");
            }

            Post post = _context.Posts.Find(postId);

            if (post == null)
            {
                return View("NotFound");
            }

            if (userId == post.User.Id || User.IsInRole("Admin") || User.IsInRole("Mod"))
            {
                return View(post);
            }
            else
            {
                return View("NotFound");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind(include: "Id, Title, Content, Created, Updated")] Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(post).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index", "Post", new { id = post.Id });
            }
            return View(post);
        }

        [Authorize(Roles = "Admin, Mod")]
        public IActionResult Manage()
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            if (userId == null)
            {
                return View("AccessDenied");
            }

            var posts = _postService.GetAll()
            .Select(p => new PostListingModel
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
                DatePosted = DateTime.Now.ToString(),
                AuthorId = p.User.Id,
                AuthorName = p.User.UserName
            });

            return View(posts);
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

        private static bool IsAuthorAdmin(ApplicationUser user)
        {
            return _userManager.GetRolesAsync(user)
                .Result.Contains("Admin");
        }

        private static bool IsAuthorMod(ApplicationUser user)
        {
            return _userManager.GetRolesAsync(user)
                .Result.Contains("Mod");
        }

        private IEnumerable<PostReplyModel> BuildPostReplies(IEnumerable<PostReplies> replies)
        {
            return replies.Select(reply => new PostReplyModel
            {
                Id = reply.Id,
                AuthorName = reply.User.UserName,
                AuthorId = reply.User.Id,
                AuthorRating = reply.User.Rating,
                Date = reply.Created,
                ReplyContent = reply.Content,
                IsAuthorAdmin = IsAuthorAdmin(reply.User),
                IsAuthorMod = IsAuthorMod(reply.User)
            });
        }
    }
}
