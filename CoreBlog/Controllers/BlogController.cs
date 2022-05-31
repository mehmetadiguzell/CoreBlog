using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreBlog.Controllers
{


    public class BlogController : Controller
    {
        private BlogManager blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = blogManager.GetBlogListWithCategory();
            return View(model);
        }
        [AllowAnonymous]
        public IActionResult BlogReadAll(int id = 0)
        {
            ViewBag.i = id;
            var model = blogManager.GetBlogById(id);
            return View(model);
        }
        public IActionResult BlogListByWriter()
        {
            Context context = new Context();
            var username = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            //var writerId = context.Writers.Where(x => x.WriterMail == username).Select(y => y.WriterID).FirstOrDefault();
            var model = blogManager.GetListWithCategoryWriterBm(writerId);
            return View(model);
        }
        public IActionResult AddBlog()
        {

            List<SelectListItem> categoryValues = (from i in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = i.CategoryName,
                                                       Value = i.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.categoryValues = categoryValues;
            return View();
        }
        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {
            Context context = new Context();
            var username = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            BlogValidator rules = new BlogValidator();
            ValidationResult result = rules.Validate(blog);
            if (result.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterID = writerId;
                blogManager.TAdd(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
        public IActionResult DeleteBlog(int id)
        {
            var model = blogManager.TGetById(id);
            blogManager.TDelete(model);
            return RedirectToAction("BlogListByWriter", "Blog");
        }

        public IActionResult EditBlog(int id)
        {
            var model = blogManager.TGetById(id);

            List<SelectListItem> categoryValues = (from i in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = i.CategoryName,
                                                       Value = i.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.categoryValues = categoryValues;

            return View(model);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            Context context = new Context();
            var username = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.BlogStatus = true;
            blog.WriterID = writerId;
            blogManager.TUpdate(blog);
            return RedirectToAction("BlogListByWriter", "Blog");
        }
    }
}
