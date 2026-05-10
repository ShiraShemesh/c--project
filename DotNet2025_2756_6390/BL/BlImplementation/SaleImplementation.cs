namespace BlImplementation;

using BO;
using BlApi;

public class SaleImplementation : ISale
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public void Create(Sale sale)
    {
        _dal.Sale.Create(sale.convert());
    }

    public void Delete(int id)
    {
        _dal.Sale.Delete(id);
    }

    public Sale? Read(int id)
    {
        var sale = _dal.Sale.Read(id);
        return sale?.convert();
    }
    public Sale? Read(Func<Sale, bool> filter)
    {
        var allSale = _dal.Sale.ReadAll();
        var boSale = allSale.Select(s => s.convert());
        return boSale.FirstOrDefault(filter);
    }
    public List<Sale?> ReadAll(Func<Sale, bool>? filter = null)
    {
        var allSale = _dal.Sale.ReadAll();
        var boSale = allSale.Select(s => s.convert()).ToList();
        return boSale;
    }

    public void Update(Sale sale)
    {
        _dal.Sale.Update(sale.convert());

    }
}
