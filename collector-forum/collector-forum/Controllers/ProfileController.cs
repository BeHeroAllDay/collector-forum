using collector_forum.Data;
using collector_forum.Data.Models;
using collector_forum.Models.ApplicationUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace collector_forum.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUser _userService;

        public ProfileController (
            UserManager<ApplicationUser> userManager,
            IApplicationUser userService)
        {
            _userManager = userManager;
            _userService = userService;
        }

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
    }
}
