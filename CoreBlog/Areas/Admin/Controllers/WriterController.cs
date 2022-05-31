using CoreBlog.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var jsonWriter = JsonConvert.SerializeObject(writers);
            return Json(jsonWriter);
        }
        public IActionResult WriterListGetById(int id)
        {
            var findWriter = writers.FirstOrDefault(x => x.id == id);
            var jsonWriter = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriter);
        }
        [HttpPost]
        public IActionResult AddWriter(WriterClass writer)
        {
            writers.Add(writer);
            var jsonWriter = JsonConvert.SerializeObject(writer);
            return Json(jsonWriter);
        }
        public IActionResult DeleteWriter(int id)
        {
            var writer = writers.FirstOrDefault(x => x.id == id);
            writers.Remove(writer);
            return Json(writer);
        }

        public IActionResult UpdateWriter(WriterClass w)
        {
            var writer = writers.FirstOrDefault(x => x.id == w.id);
            writer.name = w.name;
            var jsonWriter = JsonConvert.SerializeObject(w);
            return Json(writer);
        }

        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass{id=1,name="Ali"},
            new WriterClass{id=2,name="Alihan"},
            new WriterClass{id=3,name="Alican"}
        };

    }
}
