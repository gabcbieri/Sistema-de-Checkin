using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CheckInAPI.Data;
using CheckInAPI.Models;

namespace CheckInAPI.Controllers
{
    [Route("api/checkin")]
    [ApiController]
    public class CheckinGetController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CheckinGetController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/checkin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Checkin>>> GetCheckins()
        {
            return await _context.Checkins.ToListAsync();
        }

        // GET: api/checkin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Checkin>> CheckinGet(int id)
        {
            var checkin = await _context.Checkins.FindAsync(id);
            if (checkin == null) return NotFound();
            return checkin;
        }
    }
}
