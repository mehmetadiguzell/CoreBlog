using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Controllers
{
    public class NotificationController : Controller
    {
        private NotificationManager notificationManager = new(new EfNotificationRepository());
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult GellAllNotification()
        {
            var model = notificationManager.GetList();
            return View(model);
        }
    }
}
