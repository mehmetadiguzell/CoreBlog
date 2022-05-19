using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.ViewComponents
{

    public class CategoryList : ViewComponent
    {
        CategoryManager categoryRepository = new CategoryManager(new EfCategoryRepository());
        public IViewComponentResult Invoke()
        {
            var model = categoryRepository.GetList();
            return View(model);
        }

    }
}
