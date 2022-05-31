using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.ViewComponents
{
    public class WriterMessageNotification : ViewComponent
    {
        Message2Manager message2Manager = new(new EfMessage2Repository());
        public IViewComponentResult Invoke()
        {
            Context context = new Context();
            var username = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var model = message2Manager.GetInboxListByWriter(writerId);
            return View(model);
        }
    }
}
