namespace BO;

public class ProductInOrder
{
    public int? ProductId { get; init; }
    public string? Name { get; init; }
    public double BasePrice { get; init; }
    public int Quantity { get; set; }
    public List<SaleInProduct> Sales { get; set; } = new();
    public double finalPrice { get; set; }

}
