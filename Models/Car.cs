using System;
namespace wt_lab2_2oop_ivanov.Models {
  public class Car : BaseEntity {
    public string Brand { get; set; }
    public string Model { get; set; }
    
    // private set защищает от прямого изменения извне
    public decimal DailyRate { get; private set; }
    public bool IsAvailable { get; set; }

    public Car(int id, string brand, string model, decimal dailyRate, bool isAvailable) : base(id) {
      Brand = brand;
      Model = model;
      UpdatePrice(dailyRate);
      IsAvailable = isAvailable;
    }

    // Метод с валидацией для инкапсулированного свойства
    public void UpdatePrice(decimal newRate) {
      if (newRate <= 0) {
          throw new ArgumentException("Стоимость аренды должна быть больше нуля.");
      }
      DailyRate = newRate;
    }

    public override void PrintInfo() {
      Console.WriteLine($"[Car #{Id}] {Brand} {Model} | Сутки: {DailyRate:C} | Доступен: {(IsAvailable ? "Да" : "Нет")} | Создано: {CreatedAt:g}");
    }
}}