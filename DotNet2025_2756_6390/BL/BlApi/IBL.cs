namespace BlApi;

public interface IBL
{
    ICustomer Customer { get; }
    IProduct Product { get; }
    ISale Sale { get; }
    IOrder Order { get; }

}
