using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.ViewComponents
{
    public class WriterMessageNotification: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            
            return View();
        }
    }
}
