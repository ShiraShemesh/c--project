using DalApi;

namespace dalList;

public class DalList : IDal
{
    public IProduct Product => new ProductImplementation();
    public ICustomer Customer => new CustomerImplementation();
    public ISale Sale => new SaleImplementation();
}
