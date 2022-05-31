using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        CommentManager commentRepository = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult PartialAddComment(Comment comment)
        {
            comment.CommentDate = DateTime.Now;
            comment.CommentStatus = true;
            commentRepository.CommentAdd(comment);
            return RedirectToAction("Index", "Blog");
        }
        public PartialViewResult CommentListByBlog()
        {

            var model = commentRepository.GetList();
            return PartialView();
        }
    }
}
