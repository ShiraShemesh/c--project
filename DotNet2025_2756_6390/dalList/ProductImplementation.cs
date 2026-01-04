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

    public Product? Read(int id)
    {
        Product item = DataSource.Products.Find(p => p?.ProductId == id);
        return item;
    }

    public List<Product?> ReadAll()
    {
        return DataSource.Products;
    }

    public void Update(Product item)
    {
        int itemIndex = DataSource.Products.FindIndex(p => p?.ProductId == item.ProductId);
        if (itemIndex == -1)
            throw new IdNotFoundExcptions($"Product with Id {item.ProductId} not found.");
        DataSource.Products[itemIndex] = item;
    }

    public void Delete(int id)
    {
        int itemIndex = DataSource.Products.FindIndex(p => p?.ProductId == id);
        if (itemIndex == -1)
            throw new IdNotFoundExcptions($"Product with Id {id} not found.");
        DataSource.Products.RemoveAt(itemIndex);
    }

}
