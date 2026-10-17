using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using wt_lab2_2oop_ivanov.Models;
using wt_lab2_2oop_ivanov.Interfaces;

namespace wt_lab2_2oop_ivanov.Services {
  public class CarManagerService : IService<Car> {
    private List<Car> _cars = new List<Car>();

    public void Add(Car item) {
      _cars.Add(item);
      Console.WriteLine($"[Service] Автомобиль {item.Brand} {item.Model} успешно добавлен в систему.");
    }

    // Перегрузка метода Add (method overloading) для добавления по параметрам напрямую
    public void Add(int id, string brand, string model, decimal rate, bool isAvailable) {
      Car newCar = new Car(id, brand, model, rate, isAvailable);
      _cars.Add(newCar);
      Console.WriteLine($"[Service] Автомобиль {brand} {model} создан и добавлен через перегруженный метод.");
    }

    public List<Car> GetAll() {
      return _cars;
    }

    public Car GetById(int id) {
      return _cars.Find(c => c.Id == id);
    }
  }
}