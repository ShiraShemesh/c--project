
using System;
using System.Collections.Generic;
using Dal;
using DalApi;
using dalList;
using DO;

namespace DalTest;
internal class Program
{
    private static readonly IDal s_dal = new DalList();

    static void Main(string[] args)
    {
        try
        {
            Initialization.Initialize(s_dal);

            
            while (true)
            {
                var choice = ShowMainMenu();
                if (choice == 0) break; 

                switch (choice)
                {
                    case 1: HandleCustomers(); break;
                    case 2: HandleProducts(); break;
                    case 3: HandleSales(); break;
                    default: Console.WriteLine("Unknown selection"); break;
                }
            }

            Console.WriteLine("Program closed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex}");
        }
    }

    private static int ShowMainMenu()
    {
        Console.WriteLine("\n=== Main Menu ===");
        Console.WriteLine("1) Customers");
        Console.WriteLine("2) Products");
        Console.WriteLine("3) Sales");
        Console.WriteLine("0) Exit");
        Console.Write("Select entity: ");
        return ReadInt(Console.ReadLine());
    }

    private static int ShowCrudMenu(string entityName)
    {
        Console.WriteLine($"\n{entityName} - CRUD Menu:");
        Console.WriteLine("1) Create");
        Console.WriteLine("2) Read by id");
        Console.WriteLine("3) Read all");
        Console.WriteLine("4) Update");
        Console.WriteLine("5) Delete");
        Console.WriteLine("0) Back");
        Console.Write("Select action: ");
        return ReadInt(Console.ReadLine());
    }

    // ----- Handlers for entities -----
    private static void HandleCustomers()
    {
        var repo = s_dal.Customer;
        while (true)
        {
            var action = ShowCrudMenu("Customer");
            if (action == 0) break;

            switch (action)
            {
                case 1: CreateCustomer(repo); break;
                case 2: DoRead(repo); break;
                case 3: DoReadAll(repo); break;
                case 4: UpdateCustomer(repo); break;
                case 5: DoDelete(repo); break;
                default: Console.WriteLine("Unknown action"); break;
            }
        }
    }

    private static void HandleProducts()
    {
        var repo = s_dal.Product;
        while (true)
        {
            var action = ShowCrudMenu("Product");
            if (action == 0) break;

            switch (action)
            {
                case 1: CreateProduct(repo); break;
                case 2: DoRead(repo); break;
                case 3: DoReadAll(repo); break;
                case 4: UpdateProduct(repo); break;
                case 5: DoDelete(repo); break;
                default: Console.WriteLine("Unknown action"); break;
            }
        }
    }

    private static void HandleSales()
    {
        var repo = s_dal.Sale;
        while (true)
        {
            var action = ShowCrudMenu("Sale");
            if (action == 0) break;

            switch (action)
            {
                case 1: CreateSale(); break;
                case 2: DoRead(repo); break;
                case 3: DoReadAll(repo); break;
                case 4: UpdateSale(); break;
                case 5: DoDelete(repo); break;
                default: Console.WriteLine("Unknown action"); break;
            }
        }
    }

    // ----- CRUD input helpers -----
    private static void CreateCustomer(ICustomer repo)
    {
        Console.Write("Name: ");
        var name = Console.ReadLine() ?? string.Empty;
        Console.Write("Address: ");
        var addr = Console.ReadLine() ?? string.Empty;
        Console.Write("Phone: ");
        var phone = Console.ReadLine() ?? string.Empty;

        var id = repo.Create(new Customer { CustomerId = 0, Name = name, Address = addr, PhoneNumber = phone });
        Console.WriteLine($"Created customer id: {id}");
    }

    private static void UpdateCustomer(ICustomer repo)
    {
        Console.Write("Enter id to update: ");
        var id = ReadInt(Console.ReadLine());
        Console.Write("Name: ");
        var name = Console.ReadLine() ?? string.Empty;
        Console.Write("Address: ");
        var addr = Console.ReadLine() ?? string.Empty;
        Console.Write("Phone: ");
        var phone = Console.ReadLine() ?? string.Empty;

        repo.Update(new Customer { CustomerId = id, Name = name, Address = addr, PhoneNumber = phone });
        Console.WriteLine("Update attempted.");
    }

    private static void CreateProduct(IProduct repo)
    {
        Console.Write("Name: ");
        var name = Console.ReadLine();
        Console.Write("Category (enum name or empty): ");
        var catStr = Console.ReadLine();
        Categories? cat = null;
        if (!string.IsNullOrWhiteSpace(catStr) && Enum.TryParse<Categories>(catStr, true, out var cval)) cat = cval;
        Console.Write("Price: ");
        var price = ReadDouble(Console.ReadLine());
        Console.Write("QuantityInStock: ");
        var qty = ReadInt(Console.ReadLine());

        var id = repo.Create(new Product { ProductId = 0, Name = name, Category = cat, Price = price, QuantityInStock = qty });
        Console.WriteLine($"Created product id: {id}");
    }

    private static void UpdateProduct(IProduct repo)
    {
        Console.Write("Enter id to update: ");
        var id = ReadInt(Console.ReadLine());
        Console.Write("Name: ");
        var name = Console.ReadLine();
        Console.Write("Category (enum name or empty): ");
        var catStr = Console.ReadLine();
        Categories? cat = null;
        if (!string.IsNullOrWhiteSpace(catStr) && Enum.TryParse<Categories>(catStr, true, out var cval)) cat = cval;
        Console.Write("Price: ");
        var price = ReadDouble(Console.ReadLine());
        Console.Write("QuantityInStock: ");
        var qty = ReadInt(Console.ReadLine());

        repo.Update(new Product { ProductId = id, Name = name, Category = cat, Price = price, QuantityInStock = qty });
        Console.WriteLine("Update attempted.");
    }

    private static void CreateSale()
    {
        Console.Write("ProductId: ");
        var pid = ReadInt(Console.ReadLine());
        Console.Write("Required Quantity: ");
        var rq = ReadInt(Console.ReadLine());
        Console.Write("Price With Sale: ");
        var price = ReadDouble(Console.ReadLine());
        Console.Write("IsClub (true/false): ");
        var isClub = bool.TryParse(Console.ReadLine(), out var b) && b;
        Console.Write("Start sale (yyyy-MM-dd) or empty: ");
        var start = ReadDate(Console.ReadLine());
        Console.Write("Finish sale (yyyy-MM-dd) or empty: ");
        var finish = ReadDate(Console.ReadLine());

        var id = s_dal.Sale.Create(new Sale { SaleId = 0, ProductId = pid, RequiedQuantity = rq, PriceWhithSale = price, IsClub = isClub, Startsale = start, FinishSale = finish });
        Console.WriteLine($"Created sale id: {id}");
    }

    private static void UpdateSale()
    {
        Console.Write("Enter id to update: ");
        var id = ReadInt(Console.ReadLine());
        Console.Write("ProductId: ");
        var pid = ReadInt(Console.ReadLine());
        Console.Write("Required Quantity: ");
        var rq = ReadInt(Console.ReadLine());
        Console.Write("Price With Sale: ");
        var price = ReadDouble(Console.ReadLine());
        Console.Write("IsClub (true/false): ");
        var isClub = bool.TryParse(Console.ReadLine(), out var b) && b;
        Console.Write("Start sale (yyyy-MM-dd) or empty: ");
        var start = ReadDate(Console.ReadLine());
        Console.Write("Finish sale (yyyy-MM-dd) or empty: ");
        var finish = ReadDate(Console.ReadLine());

        s_dal.Sale.Update(new Sale { SaleId = id, ProductId = pid, RequiedQuantity = rq, PriceWhithSale = price, IsClub = isClub, Startsale = start, FinishSale = finish });
        Console.WriteLine("Update attempted.");
    }

    // ----- Generic CRUD helpers -----
    private static void DoRead<T>(ICrud<T> repo)
    {
        Console.Write("Enter id: ");
        Console.WriteLine(repo.Read(ReadInt(Console.ReadLine())));
    }

    private static void DoReadAll<T>(ICrud<T> repo)
    {
        PrintAll(repo.ReadAll());
    }

    private static void DoDelete<T>(ICrud<T> repo)
    {
        Console.Write("Enter id to delete: ");
        repo.Delete(ReadInt(Console.ReadLine()));
        Console.WriteLine("Delete attempted.");
    }

    // ----- Utilities -----
    private static int ReadInt(string? input)
    {
        if (int.TryParse(input, out var v)) return v;
        return 0; // as specified, no validation logic beyond TryParse
    }

    private static double? ReadDouble(string? input)
    {
        if (double.TryParse(input, out var v)) return v;
        return null;
    }

    private static DateTime? ReadDate(string? input)
    {
        if (DateTime.TryParse(input, out var d)) return d;
        return null;
    }

    private static void PrintAll<T>(List<T> items)
    {
        foreach (var item in items)
            Console.WriteLine(item);
        Console.WriteLine($"Total: {items.Count}\n");
    }








}
