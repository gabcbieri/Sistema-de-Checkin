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

        [HttpPost]
        public async Task<ActionResult<Checkin>> PostCheckin(Checkin checkin)
        {
            _context.Checkins.Add(checkin);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                actionName: "CheckinGet",      
                controllerName: "CheckinGet",  
                routeValues: new { id = checkin.Id },
                value: checkin);
        }
    }
}