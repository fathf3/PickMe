using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PickMe.Core.Models;
using PickMe.Core.ViewModels;

namespace PickMe.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList(); // Kullanıcıları al
            var userRoles = new List<UserRolesViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user); // Kullanıcı rollerini al
                userRoles.Add(new UserRolesViewModel
                {
                    User = user,
                    Roles = roles
                });
            }

            var roles2 = await _roleManager.Roles.ToListAsync(); // Roller  alınıyor
            ViewBag.Roles = roles2;

            return View(userRoles);
        }
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRole(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                TempData["WarningMessage"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("Index"); // Kullanıcı listesine yönlendir
            }

            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                TempData["WarningMessage"] = "Böyle bir rol mevcut değil.";
                return RedirectToAction("Index");
            }

            if (await _userManager.IsInRoleAsync(user, roleName))
            {
                TempData["WarningMessage"] = "Kullanıcı zaten bu rolde.";
                return RedirectToAction("Index");
            }

            // Eğer başarılı olursa
            TempData["SuccessMessage"] = "Rol başarıyla atandı.";

            await _userManager.AddToRoleAsync(user, roleName);
            return RedirectToAction("Index");
        }
        public IActionResult RoleList()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }
        public IActionResult CreateRole()
        {
            return View();
        }

        // Yeni rol oluşturma işlemi (POST)
        [HttpPost]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (!string.IsNullOrWhiteSpace(roleName))
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(roleName));

                if (result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RemoveUserRole(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                TempData["WarningMessage"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("Index");
            }

            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                TempData["WarningMessage"] = "Böyle bir rol mevcut değil.";
                return RedirectToAction("Index");
            }

            if (!await _userManager.IsInRoleAsync(user, roleName))
            {
                TempData["WarningMessage"] = "Kullanıcı bu rolde değil.";
                return RedirectToAction("Index");
            }

            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Kullanıcı rolü başarıyla kaldırıldı.";
            }
            else
            {
                TempData["ErrorMessage"] = "Rol silme işlemi sırasında bir hata oluştu.";
            }

            return RedirectToAction("Index");
        }
    }
}


