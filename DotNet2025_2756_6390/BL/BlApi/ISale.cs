namespace BlApi;

using BO;

public interface ISale
{
    void Create(Sale item);
    Sale? Read(int id);
    Sale? Read(Func<Sale, bool> filter);
    List<Sale?> ReadAll(Func<Sale, bool>? filter = null);
    void Update(Sale item);
    void Delete(int id);
}
