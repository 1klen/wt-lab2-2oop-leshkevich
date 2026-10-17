using System;
namespace wt_lab2_2oop_ivanov.Models {
  public class Client : BaseEntity {
    public string FullName { get; set; }
    public string LicenseNumber { get; private set; }

    public Client(int id, string fullName, string licenseNumber) : base(id) {
      FullName = fullName;
      LicenseNumber = licenseNumber;
    }

    public override void PrintInfo() {
      Console.WriteLine($"[Client #{Id}] Клиент: {FullName} | Водит. удостоверение: {LicenseNumber} | Регистрация: {CreatedAt:g}");
    }
}}