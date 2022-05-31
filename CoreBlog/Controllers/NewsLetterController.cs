using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Controllers
{
    [AllowAnonymous]
    public class NewsLetterController : Controller
    {
        private NewsLetterManager newsLetterManager = new NewsLetterManager(new EfNewsLetterRepository());
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SubscribeMail(NewsLetter newsLetter)
        {
            newsLetter.MailStatus = true;
            newsLetterManager.NewsLetterAdd(newsLetter);
            return RedirectToAction("Index", "Blog");
        }
    }
}
