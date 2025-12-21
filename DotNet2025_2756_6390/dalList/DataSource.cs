using DO;

namespace Dal;

internal static class DataSource
{
    internal static List<DO.Customer> Customers = new List<DO.Customer>();
    internal static List<DO.productProduct> productProducts = new List<DO.productProduct>();
    internal static List<DO.Sale> Sales = new List<DO.Sale>();
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
    internal const int CustomerID = 1;
    private static int customerIdCounter = CustomerID;
    public static int CustomerIdCounter
    {
        get { return ++customerIdCounter; }

    }
}
