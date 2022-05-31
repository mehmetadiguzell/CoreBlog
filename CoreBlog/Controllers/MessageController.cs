
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager message2Manager = new(new EfMessage2Repository());
        Context context = new Context();
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
        public IActionResult MessageDetails(int id)
        {
            var model = message2Manager.TGetById(id);
            return View(model);
        }
        public IActionResult SandMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SandMessage(Message2 message)
        {
            var username = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            message.SenderID = writerId;
            message.RecevierID = 1;
            message.Status = true;
            message.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message2Manager.TAdd(message);
            return View();
        }
    }
}
