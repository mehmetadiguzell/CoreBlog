using BlogApiDemo.DataAccesLayer;
using Microsoft.AspNetCore.Mvc;

namespace BlogApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using (Context db = new Context())
            {
                var model = db.Employees.ToList();
                return Ok(model);
            }
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            using (Context db = new Context())
            {
                var model = db.Employees.Add(employee);
                db.SaveChanges();
                return Ok(model);
            }
        }
        [HttpGet("{id}")]
        public IActionResult EmployeeGet(int id)
        {
            using (Context db = new Context())
            {
                var model = db.Employees.FirstOrDefault(x => x.Id == id);
                if (model == null)
                {
                    return NotFound();
                }
                return Ok(model);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            using (Context db = new Context())
            {
                var model = db.Employees.FirstOrDefault(x => x.Id == id);
                if (model == null)
                {
                    return NotFound();
                }
                db.Employees.Remove(model);
                db.SaveChanges();
                return Ok(model);
            }
        }

        [HttpPut]
        public IActionResult UpdateEmployee(Employee employee)
        {
            using (Context db = new Context())
            {
                var model = db.Employees.FirstOrDefault(x => x.Id == employee.Id);
                if (model == null)
                {
                    return NotFound();
                }
                model.Name = employee.Name;
                db.SaveChanges();
                return Ok(model);
            }
        }
    }
}
