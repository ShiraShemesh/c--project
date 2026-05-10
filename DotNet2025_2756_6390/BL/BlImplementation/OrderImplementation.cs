namespace BlImplementation;

using DalApi;
using BlApi;
using BO;

public class OrderImplementation : IOrder
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

  

    public void SearchSaleForProduct(ProductInOrder product, bool preferCustomer)
    {
        // שליפת כל המבצעים התוקפים עבור המוצר הנבחר
        var allSales = _dal.Sale.ReadAll();

        List<DO.Sale> relevantSales = new();

        // סינון המבצעים לפי קריטריונים
        foreach (var sale in allSales)
        {
            // בדיקה שמדובר במוצר הנכון
            if (sale.ProductId != product.ProductId)
                continue;

            // בדיקה שהמבצע בתוקף
            if (sale.Startsale > DateTime.Now || sale.FinishSale < DateTime.Now)
                continue;

            // בדיקה שהכמות בהזמנה עומדת בדרישה
            if (product.Quantity < sale.RequiedQuantity)
                continue;

            // אם הלקוח לא מועדף, המבצע חייב להיות זמין לכל הלקוחות
            if (!preferCustomer && (sale.IsClub ?? false))
                continue;

            relevantSales.Add(sale);
        }

        // מיון לפי מחיר ליחידה (כדאיות המבצע)
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

        // עבור על רשימת המבצעים
        foreach (var sale in product.Sales)
        {
            // אם הכמות קטנה מהנדרש למבצע זה
            if (count < sale.Quantity)
                continue;

            // חישוב כמה פעמים ניתן להשתמש במבצע זה
            int timesUsed = count / sale.Quantity;

            // הוספת מחיר המבצע
            totalPrice += (timesUsed * sale.Quantity * sale.Price);

            // עדכון הכמות הנותרת (שארית החלוקה)
            count = count % sale.Quantity;

            // שמירת המבצע שמומש
            appliedSales.Add(sale);

            // אם נמצמה כל הכמות - יוצאים מהלולאה
            if (count == 0)
                break;
        }

        // הוספת המחיר הבסיסי לכמות שנשארה
        totalPrice += count * product.BasePrice;

        // עדכון המוצר
        product.finalPrice = totalPrice;
        product.Sales = appliedSales;
    }

    public void CalcTotalPrice(Order order)
    {
        double totalPrice = 0;

        // סכום המחירים של כל המוצרים בהזמנה
        foreach (var product in order.Products)
        {
            totalPrice += product.finalPrice;
        }

        order.TotalPrice = totalPrice;
    }

    public IEnumerable<SaleInProduct> AddProductToOrder(Order order, int productId, int amount)
    {
        // 1. שליפת המוצר מה-DAL
        var doProduct = _dal.Product.Read(productId);
        if (doProduct == null)
            throw new Exception($"Product with ID {productId} does not exist.");

        // 2. חיפוש המוצר ברשימת המוצרים בהזמנה
        var productInOrder = order.Products.FirstOrDefault(p => p.ProductId == productId);

        if (productInOrder != null)
        {
            // המוצר קיים בהזמנה - עדכון הכמות
            int newQuantity = productInOrder.Quantity + amount;

            // אם הכמות החדשה אפס או שלילית - מסירים את המוצר
            if (newQuantity <= 0)
            {
                order.Products.Remove(productInOrder);
                CalcTotalPrice(order);
                return new List<SaleInProduct>();
            }

            // בדיקה שיש מספיק במלאי
            if ((doProduct.QuantityInStock ?? 0) < newQuantity)
                throw new Exception($"Not enough stock. Requested: {newQuantity}, Available: {doProduct.QuantityInStock}");

            // עדכון הכמות
            productInOrder.Quantity = newQuantity;
        }
        else
        {
            // המוצר לא קיים בהזמנה - הוספה חדשה
            if (amount <= 0)
                throw new Exception("Cannot add a new product with zero or negative quantity.");

            if ((doProduct.QuantityInStock ?? 0) < amount)
                throw new Exception($"Not enough stock. Requested: {amount}, Available: {doProduct.QuantityInStock}");

            // יצירת מוצר חדש בהזמנה
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

        // 5. חיפוש המבצעים המתאימים
        SearchSaleForProduct(productInOrder, order.IsPreferredCustomer);

        // 6. חישוב המחיר למוצר זה כולל מימוש המבצעים
        CalcTotalPriceForProduct(productInOrder);

        // 7. חישוב המחיר הסופי להזמנה
        CalcTotalPrice(order);

        // 8. החזרת המבצעים שמומשו
        return productInOrder.Sales;
    }

    public void DoOrder(Order order)
    {
        // עבור כל מוצר בהזמנה - עדכון המלאי בחזרה ל-DAL
        foreach (var productInOrder in order.Products)
        {
            var doProduct = _dal.Product.Read((int)(productInOrder.ProductId ?? 0));

            if (doProduct == null)
                throw new Exception($"Product with ID {productInOrder.ProductId} does not exist.");

            // בדיקה שיש מספיק במלאי
            if ((doProduct.QuantityInStock ?? 0) < productInOrder.Quantity)
                throw new Exception($"Cannot complete order. Not enough stock for product '{doProduct.Name}'.");

            // עדכון המלאי - הורדה של הכמות שנהוגדה בהזמנה
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