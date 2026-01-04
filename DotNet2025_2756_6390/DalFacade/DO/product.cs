namespace DO;

public  record Product(int ProductId, string? Name=null, Categories? Category=null, double? Price=null, int? QuantityInStock = null)
{
    public Product() : this(0)
    {
    }

    public override string ToString()
    {
        return $"Product ID: {this.ProductId}, Name: {this.Name}, Category: {this.Category}, Price: {this.Price}, QuantityInStock:{this.QuantityInStock}";
    }

}
