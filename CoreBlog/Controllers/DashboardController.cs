using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Controllers
{
    public class DashboardController : Controller
    {

        public IActionResult Index()
        {
            using (Context context = new Context())
            {
                var username = User.Identity.Name;
                var userMail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
                var writerId = context.Writers.Where(x => x.WriterMail == username).Select(y => y.WriterID).FirstOrDefault();
                ViewBag.v1 = context.Blogs.Count();
                ViewBag.v2 = context.Blogs.Where(x => x.WriterID == writerId).Count();
                ViewBag.v3 = context.Categories.Count();
            }
            return View();
        }
    }
}
