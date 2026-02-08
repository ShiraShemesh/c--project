using DO;

namespace DalApi;
public interface ICrud<T>
{
    int Create(T item);
    T? Read(int id);
    T? read(Func<T,bool> filter);
    List<T?> ReadAll(Func<T, bool>? filter = null);
    void Update(T item);
    void Delete(int id);
}
