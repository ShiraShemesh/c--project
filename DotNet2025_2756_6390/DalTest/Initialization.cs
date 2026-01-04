using DO;
using DalApi;
namespace Dal;

internal static class Initialization
{

    private static IDal? s_dal;
    private static void CreateProduct(IProduct product)
    {
        product.Create(new Product { Name = "Running Shoes", Category = Categories.SPORTS, Price = 89.9, QuantityInStock = 50 });
        product.Create(new Product { Name = "High Heels", Category = Categories.ELEGANT, Price = 120.0, QuantityInStock = 12 });
        product.Create(new Product { Name = "Kids Sandals", Category = Categories.CHILDREN, Price = 45.5, QuantityInStock = 30 });
        product.Create(new Product { Name = "Leather Boots", Category = Categories.MEN, Price = 150.0, QuantityInStock = 10 });
        product.Create(new Product { Name = "Casual Sneakers", Category = Categories.WOMEN, Price = 75.0, QuantityInStock = 25 });
    }
    private static void CreateCustomer(ICustomer customer)
    {
        customer.Create(new Customer { CustomerId = 1001, Name = "Yonni Smith", Address = "Main Street 10, New York", PhoneNumber = "050-1234567" });
        customer.Create(new Customer { CustomerId = 1002, Name = "Mali Davis", Address = "Oak Avenue 45, London", PhoneNumber = "052-7654321" });
        customer.Create(new Customer { CustomerId = 1003, Name = "Michael Brown", Address = "Pine Road 7, Tel Aviv", PhoneNumber = "054-9876543" });
        customer.Create(new Customer { CustomerId = 1004, Name = "Sarah Wilson", Address = "Maple Drive 12, Paris", PhoneNumber = "053-1112233" });
        customer.Create(new Customer { CustomerId = 1005, Name = "David Miller", Address = "Cedar Lane 88, Berlin", PhoneNumber = "058-4445566" });
    }
    private static void CreateSale(ISale sale)
    {
        sale.Create(new Sale { ProductId = 101, RequiedQuantity = 2, PriceWhithSale = 150.0, IsClub = true, Startsale = new DateTime(2024, 1, 1), FinishSale = new DateTime(2024, 1, 31) });
        sale.Create(new Sale { ProductId = 104, RequiedQuantity = 1, PriceWhithSale = 450.0, IsClub = false, Startsale = new DateTime(2024, 2, 10), FinishSale = new DateTime(2024, 2, 20) });
        sale.Create(new Sale { ProductId = 105, RequiedQuantity = 3, PriceWhithSale = 200.0, IsClub = true, Startsale = new DateTime(2024, 3, 5), FinishSale = new DateTime(2024, 3, 15) });
        sale.Create(new Sale { ProductId = 102, RequiedQuantity = 1, PriceWhithSale = 99.9, IsClub = false, Startsale = new DateTime(2024, 4, 1), FinishSale = new DateTime(2024, 4, 7) });
        sale.Create(new Sale { ProductId = 103, RequiedQuantity = 2, PriceWhithSale = 75.0, IsClub = true, Startsale = new DateTime(2024, 5, 20), FinishSale = new DateTime(2024, 6, 20) });
    }
    public static void Initialize(IDal dal)
    {
        s_dal = dal;
        CreateCustomer(dal.Customer);
        CreateProduct(dal.Product);
        CreateSale(dal.Sale);
    }
}
