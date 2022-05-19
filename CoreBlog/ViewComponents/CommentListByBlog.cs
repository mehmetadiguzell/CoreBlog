using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.ViewComponents
{
    public class CommentListByBlog : ViewComponent
    {

        public IViewComponentResult Invoke(int id = 0)
        {
            CommentManager commentRepository = new CommentManager(new EfCommentRepository());
            var model = commentRepository.GetList(id);
            ViewBag.Count = model.Count;
            return View(model);
        }
    }
}
