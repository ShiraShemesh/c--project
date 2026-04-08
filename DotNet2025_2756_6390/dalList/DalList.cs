using System.ComponentModel;
using DalApi;

namespace Dal;

internal sealed class DalList : IDal
{
    public IProduct Product => new ProductImplementation();
    public ICustomer Customer => new CustomerImplementation();
    public ISale Sale => new SaleImplementation();
    private static readonly IDal instance = new DalList();
    public static IDal Instance { get => instance; }


    private DalList()
    {

    }
}
