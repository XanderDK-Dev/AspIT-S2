using DataAccess;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookerController : Controller
    {
        [HttpGet]
        public ActionResult<List<Booker>> GetBooker()
        {
            Repository repository = new();
            List<Booker> booker = repository.GetBooker();
            return Ok(booker);
        }
        [HttpGet("id/{Id}")]

        [HttpPost]
        public void MakeBooker(Booker booker)
        {
            Repository repository = new();
            repository.MakeBooker(booker);
        }
    }
}
