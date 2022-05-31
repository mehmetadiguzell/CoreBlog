using BusinessLayer.Concrete;
using CoreBlog.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Controllers
{
    public class WriterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        UserManager userManager = new UserManager(new EfUserRepository());
        public IActionResult Index()
        {
            Context context = new Context();
            var username = User.Identity.Name;
            var writerName = context.Writers.Where(x => x.WriterMail == username).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.user = username;
            ViewBag.user2 = writerName;
            Context db = new Context();

            return View();
        }
        public PartialViewResult Navbar()
        {
            return PartialView();
        }
        public PartialViewResult Footer()
        {
            return PartialView();
        }

        public async Task<IActionResult> WriterEditProfile()
        {
            //Context context = new Context();

            //var username = User.Identity.Name;
            //var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            //var userid = context.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            //var model = userManager.TGetById(userid);

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateWM updateWM = new UserUpdateWM();
            updateWM.imgurl = values.ImgUrl;
            updateWM.namesurname = values.NameSurname;
            updateWM.mail = values.Email;
            updateWM.username = values.UserName;
            return View(updateWM);
        }


        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateWM updateWM)
        {
            //WriterValidator rules = new WriterValidator();
            //ValidationResult result = rules.Validate(appUser);
            //if (result.IsValid)
            //{
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.ImgUrl = updateWM.imgurl;
            values.NameSurname = updateWM.namesurname;
            values.Email = updateWM.mail;
            values.UserName = updateWM.username;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, updateWM.password);
            var result = await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "Dashboard");
            //}
            //else
            //{
            //    foreach (var item in result.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}
            //return View();
        }
        [AllowAnonymous]
        public IActionResult WriterAdd()
        {

            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfilImage writer)
        {
            Writer w = new Writer();
            if (writer.WriterImage != null)
            {
                var extension = Path.GetExtension(writer.WriterImage.FileName);
                var newImage = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/writerimagefile/", newImage);
                var stream = new FileStream(location, FileMode.Create);
                writer.WriterImage.CopyTo(stream);
                w.WriterImage = newImage;
            }
            w.WriterMail = writer.WriterMail;
            w.WriterStatus = true;
            w.WriterAbout = writer.WriterAbout;
            w.WriterPassword = writer.WriterPassword;
            w.WriterName = writer.WriterName;
            writerManager.TAdd(w);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
