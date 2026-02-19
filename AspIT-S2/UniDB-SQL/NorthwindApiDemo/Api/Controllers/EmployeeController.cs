using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities;
using DataAccess;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Employee>> GetAllEmployees()
        {
            Repository repository = new();
            List<Employee> employees = repository.GetAllEmployees();
            return Ok(employees);
        }
        [HttpGet("id/{id}")]

        public ActionResult<Employee>GetEmployeeById(int id)
        {
            Repository repository = new();
            Employee e = repository.FindEmployeeBy(id);
            return Ok(e);
        }

        [HttpGet("{startdate}, {enddate}")]
        public ActionResult<List<Employee>>GetEmployeesByHireDate(DateTime startdate, DateTime enddate)
        {
            Repository repository = new();
            List<Employee> e = repository.FindEmployeeWith(startdate, enddate);
            return Ok(e);
        }

        [HttpGet("city/{city}")]
        public ActionResult<List<Employee>> GetEmployeeByCity(string city)
        {
            Repository repository = new();
            List<Employee> employees = repository.GetEmployeeBy(city);
            return Ok(employees);
        }

        [HttpGet("title/{title}")]
        public ActionResult<List<Employee>> GetEmployeeByTitle(string title)
        {
            Repository repository = new();
            List<Employee> employees = repository.GetByTitle(title);
            return Ok(employees);
        }

        [HttpPost]
        public void AddNewEmployee(Employee employee)
        {
            Repository repository = new();
            repository.Insert(employee);
        }

        [HttpPut]
        public void Update(Employee employee)
        {
            Repository repository = new();
            repository.Update(employee);
        }

        [HttpDelete]
        public void DeleteEmployee(int id)
        {
            Repository repository = new();
            repository.DeleteEmployee(id);
        }
    }
}
