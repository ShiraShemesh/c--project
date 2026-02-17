using Dal;
using DalApi;
using DO;
using System.Reflection;
using Tools;

namespace dalList;

internal class SaleImplementation : ISale
{
    public int Create(Sale item)
    {
        Sale final = item with { SaleId = Config.SaleIdCounter };
        DataSource.Sales.Add(final);
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                             MethodBase.GetCurrentMethod().Name,
                             $"Sale with Id: {item.SaleId} created.");
        return final.SaleId;
    }
    public Sale? Read(Func<Sale, bool> filter)
    {
        var first = from sale in DataSource.Sales
                    where filter(sale)
                    select sale;
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                            MethodBase.GetCurrentMethod().Name,
                            $"Sale readed with filter func .");
        return first.FirstOrDefault();
    }


    public Sale? Read(int id)
    {
        Sale item = DataSource.Sales.Find(p => p?.SaleId == id);
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                              MethodBase.GetCurrentMethod().Name,
                              $"Sale read by id: {id}.");
        return item;
    }
    public List<Sale?> ReadAll(Func<Sale, bool>? filter = null)
    {
        if (filter == null)
            return DataSource.Sales.ToList();
        var dataFilter = from sale in DataSource.Sales
                         where filter(sale)
                         select sale;
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                              MethodBase.GetCurrentMethod().Name,
                              $"Sale readed all.");
        return dataFilter.ToList();
    }

    public void Update(Sale item)
    {
        Delete(item.SaleId);
        Create(item);
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                             MethodBase.GetCurrentMethod().Name,
                             $"Sale by id: {item.SaleId} , update .");
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
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                            MethodBase.GetCurrentMethod().Name,
                            $"Sale by id: {id} delete .");
    }


}
