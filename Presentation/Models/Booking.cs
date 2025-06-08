namespace BookingService.Models;

public class Booking
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Tickets { get; set; }
    public DateTime BookingDate { get; set; } = DateTime.UtcNow;
}
