using Microsoft.AspNetCore.Mvc;
using Entities;
using DataAccess;

namespace BookingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : Controller
    {
        [HttpGet]
        public ActionResult<List<Bookings>> GetBookings()
        {
            Repository repository = new();
            List<Bookings> bookings = repository.GetBookings();
            return Ok(bookings);
        }
        [HttpGet("id/{Id}")]

        [HttpPost]
        public void MakeBooking(Bookings bookings)
        {
            Repository repository = new();
            repository.MakeBooking(bookings);
        }
    }
}
