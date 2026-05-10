namespace BlImplementation;

using BO;
using BlApi;

public class ProductImplementation : IProduct
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public void Create(Product product)
    {
        _dal.Product.Create(product.convert());
    }

    public void Delete(int id)
    {
        _dal.Product.Delete(id);
    }

    public bool CustomerExist(int id)
    {
        var product = _dal.Product.Read(id);
        return product != null;
    }

    public Product? Read(int id)
    {
        var product = _dal.Product.Read(id);
        return product?.convert();
    }
    public Product? Read(Func<Product, bool> filter)
    {
        var allProduct = _dal.Product.ReadAll();
        var boProduct = allProduct.Select(p => p.convert());
        return boProduct.FirstOrDefault(filter);
    }
    public List<Product?> ReadAll(Func<Product, bool>? filter = null)
    {
        var allProduct = _dal.Product.ReadAll();
        var boProduct = allProduct.Select(p => p.convert()).ToList();
        return boProduct;
    }

    public void Update(Product product)
    {
        _dal.Product.Update(product.convert());

    }

    public void SaleInProduct(ProductInOrder product, bool preferCustomer)
    {
        //???????
        throw new NotImplementedException();
    }
}
