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
        int itemIndex = DataSource.Sales.FindIndex(p => p?.SaleId == item.SaleId);
        if (itemIndex == -1)
            throw new IdNotFoundExcptions($"Sale with Id {item.SaleId} not found.");
        DataSource.Sales[itemIndex] = item;
    }

    public void Delete(int id)
    {
        int itemIndex = DataSource.Sales.FindIndex(p => p?.SaleId == id);
        if (itemIndex == -1)
            throw new IdNotFoundExcptions($"Sale with Id {id} not found.");
        DataSource.Sales.RemoveAt(itemIndex);
    }

}
