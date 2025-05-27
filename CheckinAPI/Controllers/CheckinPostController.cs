using Microsoft.AspNetCore.Mvc;
using CheckInAPI.Data;
using CheckInAPI.Models;

namespace CheckInAPI.Controllers
{
    [Route("api/checkin")]
    [ApiController]
    public class CheckinPostController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CheckinPostController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/checkin
        [HttpPost]
        public async Task<ActionResult<Checkin>> PostCheckin(Checkin checkin)
        {
            _context.Checkins.Add(checkin);
            await _context.SaveChangesAsync();

            // Retorna Created (201) apontando para GET api/checkin/{id}
            return CreatedAtAction(
                actionName: "CheckinGet",      // nome da action GET no CheckinGetController
                controllerName: "CheckinGet",  // nome do controller sem "Controller"
                routeValues: new { id = checkin.Id },
                value: checkin);
        }
    }
}