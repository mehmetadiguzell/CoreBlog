using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private ContactManager contactManager = new(new EfContactRepository());
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contact.ContactDate = DateTime.Now;
            contact.ContactStatus = true;
            contactManager.ContactAdd(contact);
            return RedirectToAction("Index", "Blog");
        }
    }
}
