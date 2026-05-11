using System.Xml.Linq;

namespace Dal;

internal class Config
{
    private static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "xml", "data-config.xml");
    private static XElement config = XElement.Load(filePath);
    public static int GetProductId
    {
        get
        {
            int currentProId = int.Parse(config.Element("ProductNum").Value);
            config.Element("ProductNum").SetValue((currentProId + 1).ToString());
            config.Save(filePath);
            return currentProId;
        }
    }


    private static int saleId;

    public static int GetSaleId
    {
        get
        {
            int currentSaleId = int.Parse(config.Element("SaleNum").Value);
            config.Element("SaleNum").SetValue((currentSaleId + 1).ToString());
            config.Save(filePath);
            return currentSaleId;
        }
    }
}
