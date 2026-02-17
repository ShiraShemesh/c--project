using Dal;
using DalApi;
using DO;
using System.Collections.Generic;
using System.Reflection;
using Tools;

namespace dalList;

internal class ProductImplementation : IProduct
{
    public int Create(Product item)
    {
        Product final = item with { ProductId = Config.ProductIdCounter };
        DataSource.Products.Add(final);
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                              MethodBase.GetCurrentMethod().Name,
                              $"Product with Id: {item.ProductId} created.");
        return final.ProductId;
    }
    public Product? Read(Func<Product, bool> filter)
    {
        var first = from product in DataSource.Products
                    where filter(product)
                    select product;
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                              MethodBase.GetCurrentMethod().Name,
                              $"Product readed with filter func .");
        return first.FirstOrDefault();
    }
    public Product? Read(int id)
    {
        Product item = DataSource.Products.Find(p => p?.ProductId == id);
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                             MethodBase.GetCurrentMethod().Name,
                             $"Product read by id: {id}.");
        return item;
    }

    public List<Product?> ReadAll(Func<Product, bool>? filter = null)
    {
        if (filter == null)
            return DataSource.Products.ToList();
        var dataFilter = from product in DataSource.Products
                         where filter(product)
                         select product;
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                              MethodBase.GetCurrentMethod().Name,
                              $"Product readed all.");
        return dataFilter.ToList();
    }

    public void Update(Product item)
    {
        Delete(item.ProductId);
        Create(item);
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                             MethodBase.GetCurrentMethod().Name,
                             $"Product by id: {item.ProductId} , update .");
    }
    public void Delete(int id)
    {
        var found = DataSource.Products
              .Select((p, idx) => new { p, idx })
              .Where(x => x.p?.ProductId == id)
              .FirstOrDefault();
        if (found is null)
            throw new IdNotFoundExcptions($"Product with Id {id} not found.");
        DataSource.Products.RemoveAt(found.idx);
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                              MethodBase.GetCurrentMethod().Name,
                              $"Product by id: {id} delete .");
    }




}
