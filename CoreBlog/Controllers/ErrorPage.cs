using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Controllers
{
    public class ErrorPage : Controller
    {
        public IActionResult Error1(int code)
        {
            return View();
        }
    }
}
