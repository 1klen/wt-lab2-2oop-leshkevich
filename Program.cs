using System;
using System.Collections.Generic;
using System.Linq;
using wt_lab2_2oop_ivanov.Models;
using wt_lab2_2oop_ivanov.Services;

class Program {
  static void Main(string[] args) {
    Console.WriteLine("==============================================");
    Console.WriteLine(" Блок 2: Коллекции и LINQ — Автосалон / Аренда");
    Console.WriteLine("==============================================");

    Console.WriteLine("\n--- УРОВЕНЬ 1: Коллекция List<T> ---");
    List<Car> rentalCars = new List<Car> {
        new Car(1, "Mercedes-Benz", "W211 E320", 45.0m, true),
        new Car(2, "BMW", "530i E60", 50.0m, false),
        new Car(3, "Audi", "A6 C6", 42.0m, true),
        new Car(4, "Volkswagen", "Passat B6", 30.0m, true),
        new Car(5, "Toyota", "Camry XV40", 35.0m, false),
        new Car(6, "Skoda", "Octavia A5", 28.0m, true),
        new Car(7, "Ford", "Mondeo IV", 32.0m, true)
    };

    Console.WriteLine($"Всего автомобилей в списке: {rentalCars.Count}");
    Console.WriteLine("Итерационный вывод через foreach:");
    foreach (var car in rentalCars) {
        car.PrintInfo();
    }

    Console.WriteLine("\n--- УРОВЕНЬ 2: Словарь Dictionary и TryGetValue ---");
    Dictionary<int, Car> carCatalog = rentalCars.ToDictionary(c => c.Id);

    int searchId = 3;
    if (carCatalog.TryGetValue(searchId, out Car? foundCar)) {
        Console.WriteLine($"Успешный поиск (ID {searchId}):");
        foundCar.PrintInfo();
    } else {
        Console.WriteLine($"Автомобиль с ID {searchId} не найден.");
    }

    int missingId = 99;
    if (carCatalog.TryGetValue(missingId, out Car? missingCar)) {
        missingCar.PrintInfo();
    } else {
        Console.WriteLine($"Безопасная проверка: Автомобиль с ID {missingId} отсутствует в словаре.");
    }

    Console.WriteLine("\n--- УРОВЕНЬ 3: LINQ Запросы и Агрегатные функции ---");

    var availableCars = rentalCars
      .Where(c => c.IsAvailable)
      .OrderByDescending(c => c.DailyRate)
      .ToList();

    Console.WriteLine("\nДоступные для аренды авто (сортировка по убыванию цены):");
    foreach (var car in availableCars) {
      car.PrintInfo();
    }

    var carModelsAndRates = rentalCars
      .Select(c => new { FullName = $"{c.Brand} {c.Model}", c.DailyRate });

    Console.WriteLine("\nПроекция данных (Марка/Модель и цена):");
    foreach (var item in carModelsAndRates) {
      Console.WriteLine($"- {item.FullName} | Стоимость: {item.DailyRate:C}");
    }

    int totalCount = rentalCars.Count;
    decimal totalSumRate = rentalCars.Sum(c => c.DailyRate);
    decimal averageRate = rentalCars.Average(c => c.DailyRate);
    decimal minRate = rentalCars.Min(c => c.DailyRate);
    decimal maxRate = rentalCars.Max(c => c.DailyRate);

    Console.WriteLine("\nСтатистика автопарка:");
    Console.WriteLine($"- Общее количество: {totalCount}");
    Console.WriteLine($"- Суммарная стоимость суток: {totalSumRate:C}");
    Console.WriteLine($"- Средняя стоимость аренды: {averageRate:C}");
    Console.WriteLine($"- Минимальная цена: {minRate:C}");
    Console.WriteLine($"- Максимальная цена: {maxRate:C}");
    
    var groupedCars = rentalCars.GroupBy(c => c.IsAvailable);

    Console.WriteLine("\nГруппировка автомобилей по доступности:");
    foreach (var group in groupedCars) {
      string status = group.Key ? "Доступны" : "Заняты/Недоступны";
      Console.WriteLine($"  [{status} - количество: {group.Count()}]");
      foreach (var car in group) {
          Console.WriteLine($"    * {car.Brand} {car.Model}");
      }
    }
  }
}