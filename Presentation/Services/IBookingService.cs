using BookingService.Models;

namespace BookingService.Services;

public interface IBookingService
{
    IEnumerable<Booking> GetAll();
    void Add(Booking booking);
}
