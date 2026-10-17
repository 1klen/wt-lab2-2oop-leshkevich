using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using wt_lab2_2oop_ivanov.Models;

namespace wt_lab2_2oop_ivanov.Services {
  public class CarAsyncService {
    public async Task ProcessSystemInitializationAsync() {
      Console.WriteLine("[Async-1] Инициализация модулей автосалона...");
      await Task.Delay(1000);
      Console.WriteLine("[Async-1] Системы успешно инициализированы.");
    }
    public async Task<List<Car>> FetchCarsFromDatabaseAsync(bool simulateError) {
      Console.WriteLine("[Async-2] Подключение к базе данных автосалона...");
      try {
          await Task.Delay(600);
          
          if (simulateError) {
            throw new InvalidOperationException("Ошибка соединения с удаленным сервером СУБД!");
          }

          List<Car> carsFromDb = new List<Car> {
            new Car(1, "Mercedes-Benz", "W211 E320", 45.0m, true),
            new Car(2, "BMW", "530i E60", 50.0m, false),
            new Car(3, "Audi", "A6 C6", 42.0m, true)
          };
          
          Console.WriteLine("[Async-2] Данные успешно получены из СУБД.");
          return carsFromDb;
      }
      catch (Exception ex) {
        Console.WriteLine($"[Async-2 [Catch]] Произошла ошибка: {ex.Message}");
        throw;
      }
      finally {
        Console.WriteLine("[Async-2 [Finally]] Соединение с базой данных закрыто.\n");
      }
    }
    public async Task LongRunningImportAsync(CancellationToken cancellationToken) {
      Console.WriteLine("[Async-3] Начинаем импорт большого архива автомобилей...");
      for (int i = 1; i <= 5; i++) {
        cancellationToken.ThrowIfCancellationRequested();
        
        Console.WriteLine($"[Async-3] Обработка пакета данных {i} из 5...");
        await Task.Delay(400, cancellationToken);
      }
      Console.WriteLine("[Async-3] Импорт успешно завершен.");
    }
  }
}