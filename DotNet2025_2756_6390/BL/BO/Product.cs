namespace BO;

public class Product
{
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public Categories? Category { get; set; }
    public double? Price { get; set; }
    public int? QuantityInStock { get; set; }
    public List<SaleInProduct> Sales { get; set; } = new();

}
