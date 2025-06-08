using BookingService.Models;
using Presentation.Data;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Services;

public class BookingService : IBookingService
{
    private readonly BookingDbContext _context;

    public BookingService(BookingDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Booking> GetAll()
    {
        try
        {
            return _context.Bookings.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fel vid hämtning av bokningar: {ex.Message}");
            return new List<Booking>();
        }
    }

    public void Add(Booking booking)
    {
        try
        {
            booking.BookingDate = DateTime.UtcNow;
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fel vid sparning av bokning: {ex.Message}");
            throw; // Låt kontrollern ta hand om felet om det behövs
        }
    }
}
