
namespace DalApi;
using DO;
public interface ISale<T>
{
    int Create(T item);
    T? Read(int id);
    List<T> ReadAll();
    void Update(T item);
    void Delete(int id);

}
