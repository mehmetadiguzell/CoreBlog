using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreBlog.Controllers
{
    public class EmployeTestController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7194/api/Default");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(values);
        }
        public IActionResult AddEmploye()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmploye(Class1 class1)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(class1);
            StringContent content = new StringContent(jsonEmployee, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7194/api/Default", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> EditEmployeAsync(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7194/api/Default/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Class1>(jsonString);
                return View(values);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployeAsync(Class1 class1)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(class1);
            StringContent content = new StringContent(jsonEmployee, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:7194/api/Default", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteEmploye(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:7194/api/Default/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
    public class Class1
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}



