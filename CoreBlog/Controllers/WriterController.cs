using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreBlog.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Controllers
{
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        public IActionResult Index()
        {
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
        [AllowAnonymous]
        public IActionResult WriterEditProfile()
        {
            var model = writerManager.TGetById(1);
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
            WriterValidator rules = new WriterValidator();
            ValidationResult result = rules.Validate(writer);
            if (result.IsValid)
            {
                writer.WriterStatus = true;
                writer.WriterImage = "deneme";
                writerManager.TUpdate(writer);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
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
            if (writer.WriterImage!=null)
            {
                var extension = Path.GetExtension(writer.WriterImage.FileName);
                var newImage=Guid.NewGuid()+extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/writerimagefile/", newImage);
                var stream =new FileStream(location,FileMode.Create);
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
