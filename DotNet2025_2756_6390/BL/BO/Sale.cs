namespace BO;

public class Sale
{
    public int SaleId { get; init; }
    public int ProductId { get; init; }
    public int RequiedQuantity { get; init; }
    public double PriceWhithSale { get; init; }
    public bool IsClub { get; init; }
    public DateTime Startsale { get; set; }
    public DateTime FinishSale { get; set; }

}
