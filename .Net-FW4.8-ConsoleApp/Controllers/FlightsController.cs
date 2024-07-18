using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TestUMS.Data; // Adjust the namespace accordingly
using TestUMS.Models; // Adjust the namespace accordingly

public class FlightsController : Controller
{
    public IActionResult Index()
    {
        return View(InMemoryDataStore.Flights);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Flight flight)
    {
        if (ModelState.IsValid)
        {
            flight.Id = InMemoryDataStore.Flights.Count + 1;
            InMemoryDataStore.Flights.Add(flight);
            return RedirectToAction(nameof(Index));
        }
        return View(flight);
    }

    public IActionResult Edit(int id)
    {
        var flight = InMemoryDataStore.Flights.FirstOrDefault(f => f.Id == id);
        if (flight == null)
        {
            return NotFound();
        }
        return View(flight);
    }

    [HttpPost]
    public IActionResult Edit(Flight flight)
    {
        if (ModelState.IsValid)
        {
            var existingFlight = InMemoryDataStore.Flights.FirstOrDefault(f => f.Id == flight.Id);
            if (existingFlight != null)
            {
                existingFlight.FlightNumber = flight.FlightNumber;
                existingFlight.AirportName = flight.AirportName;
                existingFlight.Plane = flight.Plane;
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
        return View(flight);
    }

    public IActionResult Delete(int id)
    {
        var flight = InMemoryDataStore.Flights.FirstOrDefault(f => f.Id == id);
        if (flight == null)
        {
            return NotFound();
        }
        InMemoryDataStore.Flights.Remove(flight);
        return RedirectToAction(nameof(Index));
    }
}
