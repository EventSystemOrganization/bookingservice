using BookingService.Services;
using Microsoft.EntityFrameworkCore;
using Presentation.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<BookingDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sql => sql.EnableRetryOnFailure()
    )
);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<IBookingService, BookingService.Services.BookingService>();

var app = builder.Build();

app.MapOpenApi();
app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
