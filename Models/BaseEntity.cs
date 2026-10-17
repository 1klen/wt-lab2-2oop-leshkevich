namespace wt_lab2_2oop_ivanov.Models {
public abstract class BaseEntity {
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }

  protected BaseEntity(int id) {
    Id = id;
    CreatedAt = DateTime.Now;
  }

  public abstract void PrintInfo();
}}