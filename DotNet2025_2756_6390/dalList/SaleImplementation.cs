using Dal;
using DalApi;
using DO;

namespace dalList;

internal class SaleImplementation : ISale
{
    public int Create(Sale item)
    {
        Sale final = item with { SaleId = Config.SaleIdCounter };
        DataSource.Sales.Add(final);
        return final.SaleId;
    }

    public Sale? Read(int id)
    {
        Sale item = DataSource.Sales.Find(p => p?.SaleId == id);
        return item;
    }

    public List<Sale?> ReadAll()
    {
        return DataSource.Sales;
    }

    public void Update(Sale item)
    {
        Delete(item.SaleId);
        Create(item);
    }

    public void Delete(int id)
    {
        var found = DataSource.Sales
              .Select((s, idx) => new { s, idx })
              .Where(x => x.s?.SaleId == id)
              .FirstOrDefault();
        if (found is null)
            throw new IdNotFoundExcptions($"Sale with Id {id} not found.");
        DataSource.Sales.RemoveAt(found.idx);
    }

}
