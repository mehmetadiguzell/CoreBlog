using CoreBlog.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignInWM userSignInWM)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userSignInWM.username, userSignInWM.password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                return View();
            }
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> Index(Writer writer)
        //{
        //    Context context = new Context();
        //    var model = context.Writers.FirstOrDefault(m => m.WriterMail == writer.WriterMail && m.WriterPassword == writer.WriterPassword);
        //    if (model != null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, writer.WriterMail)
        //        };
        //        var userIdentity = new ClaimsIdentity(claims, "a");
        //        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
        //        await HttpContext.SignInAsync(principal);
        //        //HttpContext.Session.SetString("username", writer.WriterMail);
        //        return RedirectToAction("Index", "Dashboard");
        //    }
        //    return View();
        //}

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
