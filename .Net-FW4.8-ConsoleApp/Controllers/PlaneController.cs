// Controllers/PlanesController.cs
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TestUMS.Data; // Adjust the namespace accordingly
using TestUMS.Models; // Adjust the namespace accordingly

public class PlanesController : Controller
{
    public IActionResult Index()
    {
        return View(InMemoryDataStore.Planes);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Plane plane)
    {
        if (ModelState.IsValid)
        {
            plane.Id = InMemoryDataStore.Planes.Count + 1;
            InMemoryDataStore.Planes.Add(plane);
            return RedirectToAction(nameof(Index));
        }
        return View(plane);
    }

    public IActionResult Edit(int id)
    {
        var plane = InMemoryDataStore.Planes.FirstOrDefault(p => p.Id == id);
        if (plane == null)
        {
            return NotFound();
        }
        return View(plane);
    }

    [HttpPost]
    public IActionResult Edit(Plane plane)
    {
        if (ModelState.IsValid)
        {
            var existingPlane = InMemoryDataStore.Planes.FirstOrDefault(p => p.Id == plane.Id);
            if (existingPlane != null)
            {
                existingPlane.Code = plane.Code;
                existingPlane.Airline = plane.Airline;
                existingPlane.Model = plane.Model;
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
        return View(plane);
    }

    public IActionResult Delete(int id)
    {
        var plane = InMemoryDataStore.Planes.FirstOrDefault(p => p.Id == id);
        if (plane == null)
        {
            return NotFound();
        }
        InMemoryDataStore.Planes.Remove(plane);
        return RedirectToAction(nameof(Index));
    }
}
