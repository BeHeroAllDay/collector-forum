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
        private readonly IApplicationUser _userService;

        private static UserManager<ApplicationUser> _userManager;

        public PostController(IPost postService, ICategory categoryService, UserManager<ApplicationUser> userManager, IApplicationUser userService)
        {
            _postService = postService;
            _categoryService = categoryService;
            _userManager = userManager;
            _userService = userService;
        }

        public IActionResult Index(int id)
        {
            var post = _postService.GetById(id);

            var replies = BuildPostReplies(post.Replies).OrderBy(reply => reply.Date);

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

            return RedirectToAction("Index", "Forum", post.Id);
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
        public IActionResult ConfirmDelete(int id)
        {
            var post = _postService.GetById(id);
            _postService.Delete(id);

            return RedirectToAction("Index", "Forum", new { id = post.Category.Id });
        }

        [HttpGet]
        public IActionResult Edit(int postId)
        {
            Post postt = _postService.GetById(postId);
            return View(postt);

            //var post = _postService.GetById(postId);

            // if (post == null)
            // {
            //     ViewBag.ErrorMessage = $"Post with ID = {postId} cannot be found";
            //     return View("NotFound");
            // }

            // var model = new NewPostModel
            // {
            //     Id = post.Id,
            //     Title = post.Title,
            //     Content = post.Content,
            //     Created = post.Created,
            //     CategoryId = post.Category.Id,
            //     CategoryName = post.Category.Title,
            //     CategoryImageUrl = post.Category.ImageUrl
            // };

            // return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Post post)
        {
            _postService.UpdateP(post);
            return RedirectToAction("Manage");
        }

        public IActionResult Manage()
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            if (userId == null)
            {
                return View("AccessDenied");
            }

            ApplicationUser user = _userManager.FindByIdAsync(userId).Result;

            var posts = _postService.GetAll()
            .Select(p => new PostListingModel
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
                CategoryId = p.Category.Id,
                CategoryName = p.Category.Title,
                CategoryImageUrl = p.Category.ImageUrl,
                DatePosted = DateTime.Now.ToString(),
                AuthorId = p.User.Id,
                AuthorName = p.User.UserName,
            }).Where(u => u.AuthorId.Equals(userId));

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

        private IEnumerable<PostReplyModel> BuildPostReplies(IEnumerable<PostReply> replies)
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
