namespace wt_lab2_2oop_ivanov.Interfaces {
  public interface IService<T> {
    void Add(T item);
    List<T> GetAll(); // список всехь элементов вернется
    T GetById(int id);
  }
}