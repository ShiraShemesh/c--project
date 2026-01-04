namespace DO;

public record Sale(int SaleId, int ProductId, int? RequiedQuantity = null,
        double? PriceWhithSale = null, bool? IsClub = null, DateTime? Startsale = null, DateTime? FinishSale = null)
{
    public Sale() : this(0, 0)
    {
    }

    public override string ToString()
    {
        return $"Sale ID: {this.SaleId}, ProductId: {this.ProductId}, RequiedQuantity: {this.RequiedQuantity}," +
            $" PriceWhithSale: {this.PriceWhithSale}, IsClub:{this.IsClub} , Startsale:{this.Startsale}, FinishSale:{this.FinishSale}";
    }
}
