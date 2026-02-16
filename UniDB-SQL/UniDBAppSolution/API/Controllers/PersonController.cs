using DataAccess;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        public List<Person> GetAllPersons()
        {
            DataHandler handler = new DataHandler();
            return handler.GetAllPersons();
        }
    }

    
}

