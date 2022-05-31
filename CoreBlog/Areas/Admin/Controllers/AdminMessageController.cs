using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        Context context = new Context();
        Message2Manager message2Manager = new(new EfMessage2Repository());
        public IActionResult InBox()
        {
            var username = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var model = message2Manager.GetInboxListByWriter(writerId);
            return View(model);
        }
        public IActionResult SendBox()
        {
            var username = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var model = message2Manager.GetSendBoxListByWriter(writerId);
            return View(model);
        }
        public IActionResult ComposeMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ComposeMessage(Message2 message)
        {
            var username = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            message.SenderID = writerId;
            message.RecevierID = 1;
            message.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.Status = true;
            message2Manager.TAdd(message);
            return RedirectToAction("Sendbox");
        }
    }
}
