namespace BlImplementation;

using DalApi;
using BlApi;
using BO;

public class OrderImplementation : IOrder
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

  

    public void SearchSaleForProduct(ProductInOrder product, bool preferCustomer)
    {
        var allSales = _dal.Sale.ReadAll();

        List<DO.Sale> relevantSales = new();

        foreach (var sale in allSales)
        {
            if (sale.ProductId != product.ProductId)
                continue;

            if (sale.Startsale > DateTime.Now || sale.FinishSale < DateTime.Now)
                continue;

            if (product.Quantity < sale.RequiedQuantity)
                continue;

            if (!preferCustomer && (sale.IsClub ?? false))
                continue;

            relevantSales.Add(sale);
        }

        product.Sales = relevantSales
            .OrderBy(s => (s.PriceWhithSale ?? 0))
            .Select(s => new SaleInProduct
            {
                SaleId = s.SaleId,
                Quantity = s.RequiedQuantity ?? 0,
                Price = s.PriceWhithSale ?? 0,
                IsForAllCustomers = !(s.IsClub ?? false)
            })
            .ToList();
    }

    public void CalcTotalPriceForProduct(ProductInOrder product)
    {
        int count = product.Quantity;
        double totalPrice = 0;
        List<SaleInProduct> appliedSales = new();

        foreach (var sale in product.Sales)
        {
            if (count < sale.Quantity)
                continue;

            int timesUsed = count / sale.Quantity;

            totalPrice += (timesUsed * sale.Quantity * sale.Price);

            count = count % sale.Quantity;

            appliedSales.Add(sale);

            if (count == 0)
                break;
        }

        totalPrice += count * product.BasePrice;

        product.finalPrice = totalPrice;
        product.Sales = appliedSales;
    }

    public void CalcTotalPrice(Order order)
    {
        double totalPrice = 0;

        foreach (var product in order.Products)
        {
            totalPrice += product.finalPrice;
        }

        order.TotalPrice = totalPrice;
    }

    public IEnumerable<SaleInProduct> AddProductToOrder(Order order, int productId, int amount)
    {
        var doProduct = _dal.Product.Read(productId);
        if (doProduct == null)
            throw new Exception($"Product with ID {productId} does not exist.");

        var productInOrder = order.Products.FirstOrDefault(p => p.ProductId == productId);

        if (productInOrder != null)
        {
            int newQuantity = productInOrder.Quantity + amount;

            if (newQuantity <= 0)
            {
                order.Products.Remove(productInOrder);
                CalcTotalPrice(order);
                return new List<SaleInProduct>();
            }

            if ((doProduct.QuantityInStock ?? 0) < newQuantity)
                throw new Exception($"Not enough stock. Requested: {newQuantity}, Available: {doProduct.QuantityInStock}");

            productInOrder.Quantity = newQuantity;
        }
        else
        {
            if (amount <= 0)
                throw new Exception("Cannot add a new product with zero or negative quantity.");

            if ((doProduct.QuantityInStock ?? 0) < amount)
                throw new Exception($"Not enough stock. Requested: {amount}, Available: {doProduct.QuantityInStock}");

            productInOrder = new ProductInOrder
            {
                ProductId = productId,
                Name = doProduct.Name,
                BasePrice = doProduct.Price ?? 0,
                Quantity = amount,
                Sales = new List<SaleInProduct>()
            };

            order.Products.Add(productInOrder);
        }

        SearchSaleForProduct(productInOrder, order.IsPreferredCustomer);

        CalcTotalPriceForProduct(productInOrder);

        CalcTotalPrice(order);

        return productInOrder.Sales;
    }

    public void DoOrder(Order order)
    {
        foreach (var productInOrder in order.Products)
        {
            var doProduct = _dal.Product.Read((int)(productInOrder.ProductId ?? 0));

            if (doProduct == null)
                throw new Exception($"Product with ID {productInOrder.ProductId} does not exist.");

            if ((doProduct.QuantityInStock ?? 0) < productInOrder.Quantity)
                throw new Exception($"Cannot complete order. Not enough stock for product '{doProduct.Name}'.");

            var updatedProduct = new DO.Product(
                doProduct.ProductId,
                doProduct.Name,
                doProduct.Category,
                doProduct.Price,
                (doProduct.QuantityInStock ?? 0) - productInOrder.Quantity
            );

            _dal.Product.Update(updatedProduct);
        }
    }
}