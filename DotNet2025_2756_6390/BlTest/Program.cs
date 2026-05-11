using BlApi;
using BO;
using Dal;

namespace BlTest;

internal class Program
{
    static readonly BlApi.IBL s_bl = BlApi.Factory.Get();

    static void Main(string[] args)
    {
        try
        {
            Initialization.Initialize();
            Console.WriteLine("BlTest");
            while (true)
            {
                var choice = ShowMainMenu();
                if (choice == 0) break;

                switch (choice)
                {
                    case 1: HandleCustomers(); break;
                    case 2: HandleProducts(); break;
                    case 3: HandleSales(); break;
                    case 4: HandleOrders(); break;
                    default: Console.WriteLine("Unknown selection"); break;
                }
            }

            Console.WriteLine("Program closed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            if (ex.InnerException != null)
                Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
        }
    }

    private static int ShowMainMenu()
    {
        Console.WriteLine("\n========== Main Menu ==========");
        Console.WriteLine("1) Customers");
        Console.WriteLine("2) Products");
        Console.WriteLine("3) Sales");
        Console.WriteLine("4) Orders");
        Console.WriteLine("0) Exit");
        Console.Write("Select entity: ");
        return ReadInt(Console.ReadLine());
    }

    private static int ShowCrudMenu(string entityName)
    {
        Console.WriteLine($"\n{entityName} - CRUD Menu:");
        Console.WriteLine("1) Add");
        Console.WriteLine("2) Read by id");
        Console.WriteLine("3) Read all");
        Console.WriteLine("4) Update");
        Console.WriteLine("5) Delete");
        Console.WriteLine("0) Back");
        Console.Write("Select action: ");
        return ReadInt(Console.ReadLine());
    }

    // ===== CUSTOMERS =====
    private static void HandleCustomers()
    {
        while (true)
        {
            var action = ShowCrudMenu("Customer");
            if (action == 0) break;

            switch (action)
            {
                case 1: AddCustomer(); break;
                case 2: ReadCustomer(); break;
                case 3: GetAllCustomers(); break;
                case 4: UpdateCustomer(); break;
                case 5: DeleteCustomer(); break;
                case 6: CheckCustomerExist(); break;
                default: Console.WriteLine("Unknown action"); break;
            }
        }
    }

    private static void AddCustomer()
    {
        try
        {
            Console.Write("Id: ");
            var id = ReadInt(Console.ReadLine());
            Console.Write("Name: ");
            var name = Console.ReadLine() ?? string.Empty;
            Console.Write("Address: ");
            var address = Console.ReadLine() ?? string.Empty;
            Console.Write("Phone: ");
            var phone = Console.ReadLine() ?? string.Empty;

            var customer = new Customer { CustomerId = id, Name = name, Address = address, PhoneNumber = phone };
            s_bl.Customer.Create(customer);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void ReadCustomer()
    {
        try
        {
            Console.Write("Enter customer id: ");
            var id = ReadInt(Console.ReadLine());
            var customer = s_bl.Customer.Read(id);
            if (customer != null)
                Console.WriteLine(customer);
            else
                Console.WriteLine("Customer not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void GetAllCustomers()
    {
        try
        {
            var customers = s_bl.Customer.ReadAll();
            if (customers.Any())
            {
                foreach (var c in customers)
                    Console.WriteLine(c);
            }
            else
                Console.WriteLine("No customers found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void UpdateCustomer()
    {
        try
        {
            Console.Write("Enter id to update: ");
            var id = ReadInt(Console.ReadLine());
            Console.Write("New Name: ");
            var name = Console.ReadLine() ?? string.Empty;
            Console.Write("New Address: ");
            var address = Console.ReadLine() ?? string.Empty;
            Console.Write("New Phone: ");
            var phone = Console.ReadLine() ?? string.Empty;

            var customer = new Customer { CustomerId = id, Name = name, Address = address, PhoneNumber = phone };
            s_bl.Customer.Update(customer);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void DeleteCustomer()
    {
        try
        {
            Console.Write("Enter id to delete: ");
            var id = ReadInt(Console.ReadLine());
            s_bl.Customer.Delete(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void CheckCustomerExist()
    {
        try
        {
            Console.Write("Enter customer id to check: ");
            var id = ReadInt(Console.ReadLine());
            if (s_bl.Customer.CustomerExist(id))
                Console.WriteLine($"Customer {id} exists.");
            else
                Console.WriteLine($"Customer {id} does not exist.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // ===== PRODUCTS =====
    private static void HandleProducts()
    {
        while (true)
        {
            var action = ShowCrudMenu("Product");
            if (action == 0) break;

            switch (action)
            {
                case 1: AddProduct(); break;
                case 2: ReadProduct(); break;
                case 3: GetAllProducts(); break;
                case 4: UpdateProduct(); break;
                case 5: DeleteProduct(); break;
                default: Console.WriteLine("Unknown action"); break;
            }
        }
    }

    private static void AddProduct()
    {
        try
        {
            Console.Write("Name: ");
            var name = Console.ReadLine() ?? string.Empty;
            Console.Write("Category (SPORTS/ELEGANT/CHILDREN/MEN/WOMEN): ");
            var catStr = Console.ReadLine() ?? string.Empty;
            Categories? category = null;
            if (!string.IsNullOrWhiteSpace(catStr) && Enum.TryParse<Categories>(catStr, true, out var cval))
                category = cval;
            Console.Write("Price: ");
            var price = ReadDouble(Console.ReadLine());
            Console.Write("Quantity in stock: ");
            var quantity = ReadInt(Console.ReadLine());

            var product = new Product { ProductId = 0, Name = name, Category = category, Price = price, QuantityInStock = quantity };
            s_bl.Product.Create(product);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void ReadProduct()
    {
        try
        {
            Console.Write("Enter product id: ");
            var id = ReadInt(Console.ReadLine());
            var product = s_bl.Product.Read(id);
            if (product != null)
                Console.WriteLine(product);
            else
                Console.WriteLine("Product not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void GetAllProducts()
    {
        try
        {
            var products = s_bl.Product.ReadAll();
            if (products.Any())
            {
                foreach (var p in products)
                    Console.WriteLine(p);
            }
            else
                Console.WriteLine("No products found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void UpdateProduct()
    {
        try
        {
            Console.Write("Enter id to update: ");
            var id = ReadInt(Console.ReadLine());
            Console.Write("New Name: ");
            var name = Console.ReadLine() ?? string.Empty;
            Console.Write("New Category: ");
            var catStr = Console.ReadLine() ?? string.Empty;
            Categories? category = null;
            if (!string.IsNullOrWhiteSpace(catStr) && Enum.TryParse<Categories>(catStr, true, out var cval))
                category = cval;
            Console.Write("New Price: ");
            var price = ReadDouble(Console.ReadLine());
            Console.Write("New Quantity: ");
            var quantity = ReadInt(Console.ReadLine());

            var product = new Product { ProductId = id, Name = name, Category = category, Price = price, QuantityInStock = quantity };
            s_bl.Product.Update(product);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void DeleteProduct()
    {
        try
        {
            Console.Write("Enter id to delete: ");
            var id = ReadInt(Console.ReadLine());
            s_bl.Product.Delete(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // ===== SALES =====
    private static void HandleSales()
    {
        while (true)
        {
            var action = ShowCrudMenu("Sale");
            if (action == 0) break;

            switch (action)
            {
                case 1: AddSale(); break;
                case 2: ReadSale(); break;
                case 3: GetAllSales(); break;
                case 4: UpdateSale(); break;
                case 5: DeleteSale(); break;
                default: Console.WriteLine("Unknown action"); break;
            }
        }
    }

    private static void AddSale()
    {
        try
        {
            Console.Write("Product id: ");
            var productId = ReadInt(Console.ReadLine());
            Console.Write("Required quantity: ");
            var requiredQty = ReadInt(Console.ReadLine());
            Console.Write("Price with sale: ");
            var price = ReadDouble(Console.ReadLine());
            Console.Write("Is club sale (true/false): ");
            var isClub = bool.TryParse(Console.ReadLine(), out var b) && b;
            Console.Write("Start date (yyyy-MM-dd): ");
            var startDate = ReadDate(Console.ReadLine());
            Console.Write("End date (yyyy-MM-dd): ");
            var endDate = ReadDate(Console.ReadLine());

            var sale = new Sale
            {
                SaleId = 0,
                ProductId = productId,
                RequiedQuantity = requiredQty,
                PriceWhithSale = price,
                IsClub = isClub,
                Startsale = (DateTime)startDate,
                FinishSale = (DateTime)endDate
            };

            s_bl.Sale.Create(sale);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void ReadSale()
    {
        try
        {
            Console.Write("Enter sale id: ");
            var id = ReadInt(Console.ReadLine());
            var sale = s_bl.Sale.Read(id);
            if (sale != null)
                Console.WriteLine(sale);
            else
                Console.WriteLine("Sale not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void GetAllSales()
    {
        try
        {
            var sales = s_bl.Sale.ReadAll();
            if (sales.Any())
            {
                foreach (var s in sales)
                    Console.WriteLine(s);
            }
            else
                Console.WriteLine("No sales found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void UpdateSale()
    {
        try
        {
            Console.Write("Enter id to update: ");
            var id = ReadInt(Console.ReadLine());
            Console.Write("Product id: ");
            var productId = ReadInt(Console.ReadLine());
            Console.Write("Required quantity: ");
            var requiredQty = ReadInt(Console.ReadLine());
            Console.Write("Price with sale: ");
            var price = ReadDouble(Console.ReadLine());
            Console.Write("Is club sale (true/false): ");
            var isClub = bool.TryParse(Console.ReadLine(), out var b) && b;
            Console.Write("Start date (yyyy-MM-dd): ");
            var startDate = ReadDate(Console.ReadLine());
            Console.Write("End date (yyyy-MM-dd): ");
            var endDate = ReadDate(Console.ReadLine());

            var sale = new Sale
            {
                SaleId = id,
                ProductId = productId,
                RequiedQuantity = requiredQty,
                PriceWhithSale = price,
                IsClub = isClub,
                Startsale = (DateTime)startDate,
                FinishSale = (DateTime)endDate
            };
            s_bl.Sale.Update(sale);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void DeleteSale()
    {
        try
        {
            Console.Write("Enter id to delete: ");
            var id = ReadInt(Console.ReadLine());
            s_bl.Sale.Delete(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // ===== ORDERS =====
    private static void HandleOrders()
    {
        while (true)
        {
            Console.WriteLine("\n===== Order Menu =====");
            Console.WriteLine("1) Create new order");
            Console.WriteLine("2) Add product to order");
            Console.WriteLine("3) Calculate total price");
            Console.WriteLine("4) Complete order");
            Console.WriteLine("0) Back");
            Console.Write("Select action: ");
            var action = ReadInt(Console.ReadLine());
            if (action == 0) break;

            switch (action)
            {
                case 1: CreateNewOrder(); break;
                case 2: AddProductToOrder(); break;
                case 3: CalculateOrderTotal(); break;
                case 4: CompleteOrder(); break;
                default: Console.WriteLine("Unknown action"); break;
            }
        }
    }

    private static Order? currentOrder = null;

    private static void CreateNewOrder()
    {
        try
        {
            Console.Write("Is this order for a preferred customer? (true/false): ");
            var isPreferred = bool.TryParse(Console.ReadLine(), out var b) && b;
            currentOrder = new Order { IsPreferredCustomer = isPreferred };
            Console.WriteLine("New order created.");
            Console.WriteLine($"Preferred customer: {isPreferred}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void AddProductToOrder()
    {
        try
        {
            if (currentOrder == null)
            {
                Console.WriteLine("No order in progress. Create a new order first.");
                return;
            }

            Console.Write("Enter product id: ");
            var productId = ReadInt(Console.ReadLine());
            Console.Write("Enter quantity: ");
            var quantity = ReadInt(Console.ReadLine());

            var sales = s_bl.Order.AddProductToOrder(currentOrder, productId, quantity);
            Console.WriteLine(sales);
            Console.WriteLine("Product added to order successfully.");
            Console.WriteLine($"Applied sales: {sales.Count()}");
            foreach (var sale in sales)
            {
                Console.WriteLine($"  - Sale ID: {sale.SaleId}, Price: {sale.Price}, Quantity: {sale.Quantity}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void CalculateOrderTotal()
    {
        try
        {
            if (currentOrder == null)
            {
                Console.WriteLine("No order in progress.");
                return;
            }

            s_bl.Order.CalcTotalPrice(currentOrder);
            Console.WriteLine($"Order total price: {currentOrder.TotalPrice}");
            Console.WriteLine("\nOrder details:");
            foreach (var product in currentOrder.Products)
            {
                Console.WriteLine($"  - {product.Name} (ID: {product.ProductId})");
                Console.WriteLine($"    Quantity: {product.Quantity}");
                Console.WriteLine($"    Final price: {product.finalPrice}");
                if (product.Sales.Any())
                {
                    Console.WriteLine($"    Applied sales:");
                    foreach (var sale in product.Sales)
                    {
                        Console.WriteLine($"      * Sale {sale.SaleId}: {sale.Price} per {sale.Quantity} units");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void CompleteOrder()
    {
        try
        {
            if (currentOrder == null)
            {
                Console.WriteLine("No order in progress.");
                return;
            }

            s_bl.Order.DoOrder(currentOrder);
            Console.WriteLine("Order completed successfully!");
            Console.WriteLine($"Final total: {currentOrder.TotalPrice}");
            currentOrder = null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // ===== UTILITIES =====
    private static int ReadInt(string? input)
    {
        if (int.TryParse(input, out var v)) return v;
        return 0;
    }

    private static double ReadDouble(string? input)
    {
        if (double.TryParse(input, out var v)) return v;
        return 0;
    }

    private static DateTime? ReadDate(string? input)
    {
        if (DateTime.TryParse(input, out var d)) return d;
        return null;
    }
}
