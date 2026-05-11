using DalApi;

namespace Dal;

public class DalXml : IDal
{
    private static readonly DalXml instance = new DalXml();
    public static DalXml Instance { get => instance; }
    private DalXml() { }
    public IProduct Product => new ProductImplementation();

    public ICustomer Customer => new CustomerImplementation();

    public ISale Sale => new SaleImplementation();
}
