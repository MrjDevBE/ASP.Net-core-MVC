// Controllers/PassengerBookingsController.cs
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TestUMS.Data; // Adjust the namespace accordingly
using TestUMS.Models; // Adjust the namespace accordingly

public class PassengerBookingsController : Controller
{
    public IActionResult Index()
    {
        return View(InMemoryDataStore.PassengerBookings);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(PassengerBooking passengerBooking)
    {
        if (ModelState.IsValid)
        {
            passengerBooking.Id = InMemoryDataStore.PassengerBookings.Count + 1;
            InMemoryDataStore.PassengerBookings.Add(passengerBooking);
            return RedirectToAction(nameof(Index));
        }
        return View(passengerBooking);
    }

    public IActionResult Edit(int id)
    {
        var passengerBooking = InMemoryDataStore.PassengerBookings.FirstOrDefault(p => p.Id == id);
        if (passengerBooking == null)
        {
            return NotFound();
        }
        return View(passengerBooking);
    }

    [HttpPost]
    public IActionResult Edit(PassengerBooking passengerBooking)
    {
        if (ModelState.IsValid)
        {
            var existingPassengerBooking = InMemoryDataStore.PassengerBookings.FirstOrDefault(p => p.Id == passengerBooking.Id);
            if (existingPassengerBooking != null)
            {
                existingPassengerBooking.Name = passengerBooking.Name;
                existingPassengerBooking.FlightNumber = passengerBooking.FlightNumber;
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
        return View(passengerBooking);
    }

    public IActionResult Delete(int id)
    {
        var passengerBooking = InMemoryDataStore.PassengerBookings.FirstOrDefault(p => p.Id == id);
        if (passengerBooking == null)
        {
            return NotFound();
        }
        InMemoryDataStore.PassengerBookings.Remove(passengerBooking);
        return RedirectToAction(nameof(Index));
    }
}
