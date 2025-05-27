using Microsoft.EntityFrameworkCore;
using CheckInAPI.Models;

namespace CheckInAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Checkin> Checkins { get; set; }
    }
}
