using collector_forum.Data;
using collector_forum.Data.Models;
using collector_forum.Models.ApplicationUser;
using collector_forum.Models.Items;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace collector_forum.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUser _userService;
        private readonly IItem _itemService;
        private readonly ApplicationDbContext _context;

        public ProfileController(
            IItem itemService,
            IApplicationUser userService,
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            _itemService = itemService;
            _userManager = userManager;
            _userService = userService;
            _context = context;
        }


        [Authorize]
        public IActionResult Create(string id)
        {

            var user = _userService.GetById(id);

            var model = new NewItemModel
            {
                UserId = user.Id,
                UserName = user.UserName
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddItem(NewItemModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);
            var item = BuildItem(model, user);

            await _itemService.Add(item);

            return RedirectToAction("Index", "Profile", new { id = item.User.Id });
        }

        private static Item BuildItem(NewItemModel model, ApplicationUser user)
        {
            return new Item
            {
                Name = model.ItemName,
                Description = model.ItemDescription,
                Added = DateTime.Now,
                User = user
            };
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            if (userId == null)
            {
                return View("AccessDenied");
            }

            var item = _itemService.GetById(id);

            if (item == null)
            {
                ViewBag.ErrorMessage = $"Item with ID = {item} cannot be found";
                return View("NotFound");
            }
            else if (userId == item.User.Id)
            {
                await _itemService.Delete(id);
                return RedirectToAction("Index", "Profile", new { id = item.User.Id });
            }
            else
            {
                return View("NotFound");
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            var item = _itemService.GetById(id);
            _itemService.Delete(id);

            return RedirectToAction("Index", "Profile", new { id = item.User.Id });
        }

        [Authorize]
        public IActionResult Detail(string id)
        {
            var user = _userService.GetById(id);
            var userRoles = _userManager.GetRolesAsync(user).Result;

            var model = new ProfileModel()
            {
                UserId = user.Id,
                UserName = user.UserName,
                UserRating = user.Rating.ToString(),
                Email = user.Email,
                MemberSince = user.RegistrationDate,
                IsAdmin = userRoles.Contains("Admin"),
                IsMod = userRoles.Contains("Mod")
            };

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit(int itemId)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            if (userId == null)
            {
                return View("AccessDenied");
            }

            var item = _itemService.GetById(itemId);
            if (item == null)
            {
                ViewBag.ErrorMessage = $"Item with ID = {itemId} cannot be found";
                return View("NotFound");
            }

            Item it = _context.Items.Find(itemId);

            if (it == null)
            {
                return View("NotFound");
            }

            if (userId == it.User.Id)
            {
                return View(it);
            }
            else if (User.IsInRole("Admin") || User.IsInRole("Mod"))
            {
                return View(it);
            }
            else
            {
                return View("NotFound");
            }
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind(include: "Id, Name, Description, Added")] Item item)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await _userManager.FindByIdAsync(userId);

                if (userId == null)
                {
                    ViewBag.ErrorMessage = $"Item with ID = {userId} cannot be found";
                    return View("NotFound");
                }
                var it = UpdateItems(item, user);
                _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();


                if (User.IsInRole("Admin") || User.IsInRole("Mod"))
                {

                    return RedirectToAction("Index", "Profile", new { id = it.User.Id });
                }

                return RedirectToAction("Index", "Profile", new { id = it.User.Id });
            }
            return View(item);
        }

        private static Item UpdateItems(Item model, ApplicationUser user)
        {
            return new Item
            {
                Name = model.Name,
                Description = model.Description,
                Added = model.Added,
                Updated = model.Updated,
                User = user
            };
        }

        [Authorize]
        public IActionResult Index(string id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            if (userId == null)
            {
                return View("AccessDenied");
            }

            var items = _itemService.GetAll()
                .Select(i => new ItemListingModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    Updated = i.Updated,
                    Added = i.Added,
                    UserId = i.User.Id,
                    UserName = i.User.UserName
                }).Where(u => u.UserId.Equals(id));

            return View(items);
        }
    }
}
