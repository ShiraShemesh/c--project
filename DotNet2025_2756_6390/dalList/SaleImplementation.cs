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

    public Sale? read(Func<Sale, bool> filter)
    {
        var first = from sale in DataSource.Sales
                    where filter(sale)
                    select sale;
        return first.FirstOrDefault();
    }

    public List<Sale?> ReadAll(Func<Sale, bool>? filter = null)
    {
        if (filter == null)
            return DataSource.Sales.ToList();
        var dataFilter = from sale in DataSource.Sales
                         where filter(sale)
                         select sale;
        return dataFilter.ToList();
    }
}
