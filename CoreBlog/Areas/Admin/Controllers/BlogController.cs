using ClosedXML.Excel;
using CoreBlog.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult ExportDynamicBlogList()
        {
            using (var workBook = new XLWorkbook())
            {
                var worksheet = workBook.Worksheets.Add("BlogList");
                worksheet.Cell(1, 1).Value = "BlogID";
                worksheet.Cell(1, 2).Value = "Blog Adı";
                int BlogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.id;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }

            }
            return View();
        }
        List<BlogModel> GetBlogList()
        {
            List<BlogModel> blogModels = new();
            using (Context c = new Context())
            {
                blogModels = c.Blogs.Select(x => new BlogModel
                {
                    id = x.BlogID,
                    BlogName = x.BlogTitle
                }).ToList();
            }
            return blogModels;
        }
        public IActionResult ExcelBlogList()
        {
            return View();
        }
    }
}
