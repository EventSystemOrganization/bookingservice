using Microsoft.EntityFrameworkCore;
using BookingService.Models;

namespace Presentation.Data
{
    public class BookingDbContext(DbContextOptions<BookingDbContext> options) : DbContext(options)
    {
        public required DbSet<Booking> Bookings { get; set; }
    }
}
