using Microsoft.AspNetCore.Mvc;
using CheckInAPI.Data;
using CheckInAPI.Models;

namespace CheckInAPI.Controllers
{
    [Route("api/checkin")]
    [ApiController]
    public class CheckinDeleteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CheckinDeleteController(AppDbContext context)
        {
            _context = context;
        }

        // DELETE: api/checkin/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCheckin(int id)
        {
            var checkin = await _context.Checkins.FindAsync(id);
            if (checkin == null) return NotFound();

            _context.Checkins.Remove(checkin);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}