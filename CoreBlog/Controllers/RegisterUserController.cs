using CoreBlog.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Controllers
{
    [AllowAnonymous]
    public class RegisterUserController : Controller
    {
        //identity ile kayıt olma
        private readonly UserManager<AppUser> _userManager;

        public RegisterUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignUpWM signUpWM)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    Email = signUpWM.Mail,
                    NameSurname = signUpWM.NameSurname,
                    UserName = signUpWM.UserName,

                };
                var result = await _userManager.CreateAsync(appUser, signUpWM.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(signUpWM);

        }
    }
}
