namespace BlApi;

using BO;

public interface IOrder
{
    IEnumerable<SaleInProduct> AddProductToOrder(Order order, int productId, int amount);

    void CalcTotalPriceForProduct(ProductInOrder product);

    void CalcTotalPrice(Order order);

    void DoOrder(Order order);

    void SearchSaleForProduct(ProductInOrder product, bool preferCustomer);
}
