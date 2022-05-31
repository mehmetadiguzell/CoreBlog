using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBlogController : Controller
    {

        private BlogManager blogManager = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var model = blogManager.GetBlogListWithCategory();
            return View(model);
        }
    }
}
