using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        private AboutManager aboutManager = new(new EfAboutRepository());
        public IActionResult Index()
        {
            var model = aboutManager.GetList();
            return View(model);
        }

        public PartialViewResult SocialMedia()
        {
            return PartialView();
        }
    }
}
