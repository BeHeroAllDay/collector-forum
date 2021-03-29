using collector_forum.Data;
using collector_forum.Data.Models;
using collector_forum.Models.ApplicationUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

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
                IsAdmin = userRoles.Contains("Admin")
            };

            return View(model);
        }

        public IActionResult Index()
        {
            var profiles = _userService.GetAll()
                .OrderByDescending(user => user.Rating)
                .Select(u => new ProfileModel
                {
                    Email = u.Email,
                    UserName = u.UserName,
                    UserRating = u.Rating.ToString(),
                    MemberSince = u.RegistrationDate
                });
            var model = new ProfileListModel
            {
                Profiles = profiles
            };

            return View(model);
        }
    }
}
