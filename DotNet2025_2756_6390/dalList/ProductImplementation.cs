using DalApi;
using Dal;
using DO;
using System.Collections.Generic;

namespace dalList;

internal class ProductImplementation : IProduct
{
    public int Create(Product item)
    {
        Product final = item with { ProductId = Config.ProductIdCounter };
        DataSource.Products.Add(final);
        return final.ProductId;
    }
    public Product? read(Func<Product, bool> filter)
    {
        var first = from product in DataSource.Products
                    where filter(product)
                    select product;
        return first.FirstOrDefault();
    }
    public Product? Read(int id)
    {
        Product item = DataSource.Products.Find(p => p?.ProductId == id);
        return item;
    }

    public List<Product?> ReadAll(Func<Product, bool>? filter = null)
    {
        if (filter == null)
            return DataSource.Products.ToList();
        var dataFilter = from product in DataSource.Products
                         where filter(product)
                         select product;
        return dataFilter.ToList();
    }

    public void Update(Product item)
    {
        Delete(item.ProductId);
        Create(item);
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
    }




}
