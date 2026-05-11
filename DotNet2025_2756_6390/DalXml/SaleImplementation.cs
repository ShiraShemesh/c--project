using DalApi;
using DO;
using System.Xml.Serialization;

namespace Dal;

internal class SaleImplementation : ISale
{

    private static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "xml", "sales.xml");
    private XmlSerializer sales = new XmlSerializer(typeof(List<Sale>));
    private List<Sale> salesList;
    public SaleImplementation()
    {
        try
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    var loaded = sales.Deserialize(reader) as List<Sale>;
                    salesList = loaded ?? new List<Sale>();
                }
            }
            else
            {
                Console.WriteLine("File does not exist, creating new list");
                salesList = new List<Sale>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading sales: {ex.Message}");
            salesList = new List<Sale>();
        }
    }

    public int Create(Sale item)
    {
        salesList.Add(item);
        SaveToFile();
        return item.SaleId;

    }

    public void Delete(int id)
    {

        Sale s = salesList.FirstOrDefault(s => s.SaleId == id);
        if (s != null)
        {
            salesList.Remove(s);
            SaveToFile();
        }
        else
        {
            Console.WriteLine($"Sale with id {id} not found.");
        }
    }

    public Sale Read(int id)
    {
        return salesList.FirstOrDefault(x => x.SaleId == id) ??
            throw new KeyNotFoundException($"Sale with id {id} not found.");
    }

    public Sale Read(Func<Sale, bool> filter)
    {
        return ReadAll(filter).FirstOrDefault() ??
            throw new KeyNotFoundException("Sale with specified filter not found.");
    }

    public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
    {
        if (filter == null)
            return salesList.ToList();
        return salesList.Where(filter).ToList();
    }
    public void Update(Sale item)
    {
        Delete(item.SaleId);
        Create(item);
        SaveToFile();
    }
    private void SaveToFile()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                sales.Serialize(writer, salesList);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to file: {ex.Message}");
            Console.WriteLine($"StackTrace: {ex.StackTrace}");
        }
    }
}
