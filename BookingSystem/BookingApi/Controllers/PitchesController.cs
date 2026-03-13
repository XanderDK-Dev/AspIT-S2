using DataAccess;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace PitchesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PitchesController : Controller
    {
        [HttpGet]
        public ActionResult<List<Pitches>> GetPitches()
        {
            Repository repository = new();
            List<Pitches> Pitches = repository.GetPitches();
            return Ok(Pitches);
        }
        [HttpGet("id/{Id}")]

        [HttpPost]
        public void MakePitch(Pitches Pitches)
        {
            Repository repository = new();
            repository.MakePitch(Pitches);
        }
    }   
}
