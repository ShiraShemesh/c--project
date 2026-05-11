using DalApi;
using DO;
using System.Xml.Serialization;

namespace Dal;

internal class ProductImplementation : IProduct
{

    private static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "xml", "products.xml");
    private XmlSerializer products = new XmlSerializer(typeof(List<Product>));
    private List<Product> productsList;
    public ProductImplementation()
    {
        try
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    var loaded = products.Deserialize(reader) as List<Product>;
                    productsList = loaded ?? new List<Product>();
                }
            }
            else
            {
                Console.WriteLine("File does not exist, creating new list");
                productsList = new List<Product>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading products: {ex.Message}");
            productsList = new List<Product>();
        }
    }

    public int Create(Product item)
    {
        productsList.Add(item);
        SaveToFile();
        return item.ProductId;
    }

    public void Delete(int id)
    {

        Product p = productsList.FirstOrDefault(p => p.ProductId == id);
        if (p != null)
        {
            productsList.Remove(p);
            SaveToFile();
        }
        else
        {
            Console.WriteLine($"Product with id {id} not found.");
        }
    }

    public Product Read(int id)
    {
        return productsList.FirstOrDefault(x => x.ProductId == id) ??
            throw new KeyNotFoundException($"Product with id {id} not found.");
    }

    public Product Read(Func<Product, bool> filter)
    {
        return ReadAll(filter).FirstOrDefault() ??
            throw new KeyNotFoundException("Product with specified filter not found.");
    }

    public List<Product> ReadAll(Func<Product, bool>? filter = null)
    {
        if (filter == null)
            return productsList.ToList();
        return productsList.Where(filter).ToList();
    }
    public void Update(Product item)
    {
        Delete(item.ProductId);
        Create(item);
        SaveToFile();
    }
    private void SaveToFile()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                products.Serialize(writer, productsList);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to file: {ex.Message}");
            Console.WriteLine($"StackTrace: {ex.StackTrace}");
        }
    }
}
