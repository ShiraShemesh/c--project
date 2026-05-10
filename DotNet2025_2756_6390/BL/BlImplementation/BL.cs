namespace BlImplementation;

using BlApi;

public class BL : IBL
{
    public ICustomer Customer => new CustomerImplementation();

    public IProduct Product => new ProductImplementation();

    public ISale Sale => new SaleImplementation();

    public IOrder Order => new OrderImplementation();
}
