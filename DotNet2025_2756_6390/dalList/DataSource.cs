using DO;
namespace Dal;

internal static class DataSource
{
    internal static List<Customer> Customers = new List<Customer>();
    internal static List<Product> Products = new List<Product>();
    internal static List<Sale> Sales = new List<Sale>();
}
internal static class Config
{
    internal const int ProductID = 123;
    private static int productIdCounter = ProductID;
    public static int ProductIdCounter
    {
        get { return ++productIdCounter; }

    }
    internal const int SaletID = 1000;
    private static int saleIdCounter = SaletID;
    public static int SaleIdCounter
    {
        get { return ++saleIdCounter; }

    }
}
