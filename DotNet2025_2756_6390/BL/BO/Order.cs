namespace BO;

public class Order
{
    public bool IsPreferredCustomer { get; init; }
    public double TotalPrice { get; set; }
    public List<ProductInOrder> Products { get; set; } = new();

}
