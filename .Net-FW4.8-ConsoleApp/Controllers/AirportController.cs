// Controllers/AirportsController.cs
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TestUMS.Data; // Adjust the namespace accordingly
using TestUMS.Models; // Adjust the namespace accordingly

public class AirportsController : Controller
{
    public IActionResult Index()
    {
        return View(InMemoryDataStore.Airports);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Airport airport)
    {
        if (ModelState.IsValid)
        {
            airport.Id = InMemoryDataStore.Airports.Count + 1;
            InMemoryDataStore.Airports.Add(airport);
            return RedirectToAction(nameof(Index));
        }
        return View(airport);
    }

    public IActionResult Edit(int id)
    {
        var airport = InMemoryDataStore.Airports.FirstOrDefault(a => a.Id == id);
        if (airport == null)
        {
            return NotFound();
        }
        return View(airport);
    }

    [HttpPost]
    public IActionResult Edit(Airport airport)
    {
        if (ModelState.IsValid)
        {
            var existingAirport = InMemoryDataStore.Airports.FirstOrDefault(a => a.Id == airport.Id);
            if (existingAirport != null)
            {
                existingAirport.Name = airport.Name;
                existingAirport.Address = airport.Address;
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
        return View(airport);
    }

    public IActionResult Delete(int id)
    {
        var airport = InMemoryDataStore.Airports.FirstOrDefault(a => a.Id == id);
        if (airport == null)
        {
            return NotFound();
        }
        InMemoryDataStore.Airports.Remove(airport);
        return RedirectToAction(nameof(Index));
    }
}
