using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Controllers
{
    public class DashboardController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            using (Context context=new Context())
            {
                ViewBag.v1 = context.Blogs.Count();
                ViewBag.v2 = context.Blogs.Where(x=>x.WriterID==1).Count();
                ViewBag.v3 = context.Categories.Count();
            }
            return View();
        }
    }
}
