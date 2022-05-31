using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace CoreBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page = 1)
        {
            var model = categoryManager.GetList().ToPagedList(page, 3);
            return View(model);
        }
        public IActionResult AddCategory()
        {
            return View();
        }
        public IActionResult CategoryStatusTrue(int id)
        {
            var model = categoryManager.TGetById(id);
            if (model.CategoryStatus == false)
            {
                model.CategoryStatus = true;
                categoryManager.TUpdate(model);
            }
            return RedirectToAction("Index");
        }
        public IActionResult CategoryStatusFalse(int id)
        {
            var model = categoryManager.TGetById(id);
            if (model.CategoryStatus)
            {
                model.CategoryStatus = false;
                categoryManager.TUpdate(model);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {

            CategoryValidator rules = new CategoryValidator();
            ValidationResult result = rules.Validate(category);
            if (result.IsValid)
            {
                category.CategoryStatus = true;
                categoryManager.TAdd(category);
                return RedirectToAction("Index", "Category");
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
    }
}
