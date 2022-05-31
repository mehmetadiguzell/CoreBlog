using CoreBlog.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryModel> categories = new List<CategoryModel>();
            categories.Add(
            new CategoryModel
            {
                categorycount = 10,
                categoryname = "Tekonoloji"
            });
            categories.Add(
           new CategoryModel
           {
               categorycount = 15,
               categoryname = "Spor"
           });
            categories.Add(
           new CategoryModel
           {
               categorycount = 18,
               categoryname = "Yazılım"
           });

            return Json(new { jsonlist = categories });
        }
    }
}
