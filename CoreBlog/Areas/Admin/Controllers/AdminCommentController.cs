using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCommentController : Controller
    {
        private CommentManager commentManager = new CommentManager(new EfCommentRepository());

        public IActionResult Index()
        {
            var model = commentManager.GetCommentListWithBlog();
            return View(model);
        }
    }
}
