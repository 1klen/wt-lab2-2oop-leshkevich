namespace wt_lab4_4mvc_leshkevich.Models;

public class Car
{
  public int Id { get; set; }
  public string BrandModel { get; set; } = string.Empty;
  public string Category { get; set; } = string.Empty;
  public decimal PricePerDay { get; set; }
  public bool IsAvailable { get; set; }
}