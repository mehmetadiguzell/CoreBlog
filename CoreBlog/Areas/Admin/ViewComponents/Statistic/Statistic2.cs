
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            using (Context context = new Context())
            {
                ViewBag.Statistic = context.Blogs.OrderByDescending(x => x.BlogID).Select(y => y.BlogTitle).Take(1).FirstOrDefault();

                ViewBag.Statistic2 = context.Contacts.Count();

                ViewBag.Statistic3 = context.Comments.Count();

            }

            return View();
        }
    }

}
