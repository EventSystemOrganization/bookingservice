using Microsoft.AspNetCore.Mvc;
using BookingService.Models;
using BookingService.Services;

namespace BookingService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingsController(IBookingService service) : ControllerBase
{
    private readonly IBookingService _service = service;

    [HttpGet]
    public ActionResult<IEnumerable<Booking>> GetAll()
    {
        return Ok(_service.GetAll());
    }

    [HttpPost]
    public IActionResult Create(Booking booking)
    {
        _service.Add(booking);
        return Ok(new { message = "Bokning mottagen!" });
    }
}
