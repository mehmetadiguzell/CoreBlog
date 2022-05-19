using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreBlog.Controllers
{

    [AllowAnonymous]
    public class BlogController : Controller
    {
        private BlogManager blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            var model = blogManager.GetBlogListWithCategory();
            return View(model);
        }
        public IActionResult BlogReadAll(int id = 0)
        {
            ViewBag.i = id;
            var model = blogManager.GetBlogById(id);
            return View(model);
        }
        public IActionResult BlogListByWriter()
        {
            var model = blogManager.GetListWithCategoryWriterBm(4);
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
            BlogValidator rules = new BlogValidator();
            ValidationResult result = rules.Validate(blog);
            if (result.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterID = 4;
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
            blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.BlogStatus = true;
            blog.WriterID = 4;
            blogManager.TUpdate(blog);
            return RedirectToAction("BlogListByWriter", "Blog");
        }
    }
}
