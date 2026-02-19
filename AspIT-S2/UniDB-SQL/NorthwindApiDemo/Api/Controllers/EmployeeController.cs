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
        [HttpGet("{id}")]

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
