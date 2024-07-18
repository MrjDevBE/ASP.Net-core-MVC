using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TestUMS.Data; // Adjust the namespace accordingly
using TestUMS.Models; // Adjust the namespace accordingly
public class HomeController : Controller
{
    public IActionResult Index()
    {
        var viewModel = new IndexViewModel
        {
            Airports = InMemoryDataStore.Airports,
            Planes = InMemoryDataStore.Planes,
            Flights = InMemoryDataStore.Flights,
            Bookings = InMemoryDataStore.PassengerBookings
        };

        return View(viewModel);
    }
}
