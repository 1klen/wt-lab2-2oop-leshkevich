using Microsoft.AspNetCore.Mvc;
using wt_lab4_4mvc_leshkevich.Models;

namespace wt_lab4_4mvc_leshkevich.Controllers;

public class CarController : Controller
{
    private static readonly List<Car> cars = new()
    {
        new Car { Id = 1, BrandModel = "Toyota Camry", Category = "Седан", PricePerDay = 120, IsAvailable = true },
        new Car { Id = 2, BrandModel = "BMW X5", Category = "Внедорожник", PricePerDay = 350, IsAvailable = true },
        new Car { Id = 3, BrandModel = "Tesla Model 3", Category = "Электрокар", PricePerDay = 250, IsAvailable = false },
        new Car { Id = 4, BrandModel = "Audi A6", Category = "Седан", PricePerDay = 200, IsAvailable = true },
        new Car { Id = 5, BrandModel = "Kia Rio", Category = "Эконом", PricePerDay = 60, IsAvailable = true }
    };

    // GET: /Car/Index
    public IActionResult Index()
    {
        return View(cars);
    }

    // GET: /Car/Details/5
    public IActionResult Details(int id)
    {
        var car = cars.FirstOrDefault(c => c.Id == id);
        if (car == null)
        {
            return NotFound();
        }
        return View(car);
    }

    // GET: /Car/Create
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Car/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Car car)
    {
        if (ModelState.IsValid)
        {
            // Генерируем ID для новой машины
            car.Id = cars.Count > 0 ? cars.Max(c => c.Id) + 1 : 1;
            cars.Add(car);
            return RedirectToAction(nameof(Index));
        }
        return View(car);
    }
    // GET: /Car/Edit/5
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var car = cars.FirstOrDefault(c => c.Id == id);
        if (car == null)
        {
            return NotFound();
        }
        return View(car);
    }

    // POST: /Car/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Car car)
    {
        if (id != car.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var existingCar = cars.FirstOrDefault(c => c.Id == id);
            if (existingCar == null)
            {
                return NotFound();
            }

            existingCar.BrandModel = car.BrandModel;
            existingCar.Category = car.Category;
            existingCar.PricePerDay = car.PricePerDay;
            existingCar.IsAvailable = car.IsAvailable;

            return RedirectToAction(nameof(Index));
        }
        return View(car);
    }

    // GET: /Car/Delete/5
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var car = cars.FirstOrDefault(c => c.Id == id);
        if (car == null)
        {
            return NotFound();
        }
        return View(car);
    }

    // POST: /Car/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var car = cars.FirstOrDefault(c => c.Id == id);
        if (car != null)
        {
            cars.Remove(car);
        }
        return RedirectToAction(nameof(Index));
    }
}