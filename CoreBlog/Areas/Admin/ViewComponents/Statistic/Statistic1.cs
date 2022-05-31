
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            using (Context context = new Context())
            {
                ViewBag.Statistic = context.Blogs.Count();

                ViewBag.Statistic2 = context.Contacts.Count();

                ViewBag.Statistic3 = context.Comments.Count();

            }

            return View();
        }
    }

}
