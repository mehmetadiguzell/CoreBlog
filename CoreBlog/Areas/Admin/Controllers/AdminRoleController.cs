using CoreBlog.Areas.Admin.Models;
using CoreBlog.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class AdminRoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AdminRoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var model = _roleManager.Roles.ToList();
            return View(model);
        }
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleWM roleWM)
        {
            if (ModelState.IsValid)
            {
                AppRole appRole = new AppRole()
                {
                    Name = roleWM.RoleName
                };
                var result = await _roleManager.CreateAsync(appRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

            }
            return View(roleWM);
        }
        public IActionResult UpdateRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            RoleUpdateWM roleUpdateWM = new RoleUpdateWM()
            {
                id = values.Id,
                name = values.Name
            };
            return View(roleUpdateWM);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleUpdateWM roleUpdate)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == roleUpdate.id);
            values.Name = roleUpdate.name;

            var result = await _roleManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result = await _roleManager.DeleteAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult UserRoleList()
        {
            var result = _userManager.Users.ToList();
            return View(result);
        }
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();
            TempData["UserId"] = user.Id;
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignWM> model = new List<RoleAssignWM>();
            foreach (var item in roles)
            {
                RoleAssignWM m = new RoleAssignWM();
                m.RoleId = item.Id;
                m.RoleName = item.Name;
                m.Exis = userRoles.Contains(item.Name);
                model.Add(m);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignWM> model)
        {
            int userId = (int)TempData["UserId"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            foreach (var item in model)
            {
                if (item.Exis)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);

                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction("UserRoleList");
        }
    }
}
