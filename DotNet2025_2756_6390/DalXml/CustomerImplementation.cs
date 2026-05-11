using DalApi;
using DO;
using System.Xml.Serialization;

namespace Dal;

internal class CustomerImplementation : ICustomer
{

    private static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "xml", "customers.xml");
    private XmlSerializer customers = new XmlSerializer(typeof(List<Customer>));
    private List<Customer> customersList;
    public CustomerImplementation()
    {
        try
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    var loaded = customers.Deserialize(reader) as List<Customer>;
                    customersList = loaded ?? new List<Customer>();
                }
            }
            else
            {
                Console.WriteLine("File does not exist, creating new list");
                customersList = new List<Customer>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading customers: {ex.Message}");
            customersList = new List<Customer>();
        }
    }

    public int Create(Customer item)
    {
        customersList.Add(item);
        SaveToFile();
        return item.CustomerId;

    }

    public void Delete(int id)
    {

        Customer c = customersList.FirstOrDefault(c => c.CustomerId == id);
        if (c != null)
        {
            customersList.Remove(c);
            SaveToFile();
        }
        else
        {
            Console.WriteLine($"Customer with id {id} not found.");
        }
    }

    public Customer Read(int id)
    {
        return customersList.FirstOrDefault(x => x.CustomerId == id) ??
            throw new KeyNotFoundException($"Customer with id {id} not found.");
    }

    public Customer Read(Func<Customer, bool> filter)
    {
        return ReadAll(filter).FirstOrDefault() ??
            throw new KeyNotFoundException("Customer with specified filter not found.");
    }

    public List<Customer> ReadAll(Func<Customer, bool>? filter = null)
    {
        if (filter == null)
            return customersList.ToList();
        return customersList.Where(filter).ToList();
    }
    public void Update(Customer item)
    {
        Delete(item.CustomerId);
        Create(item);
        SaveToFile();
    }
    private void SaveToFile()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                customers.Serialize(writer, customersList);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to file: {ex.Message}");
            Console.WriteLine($"StackTrace: {ex.StackTrace}");
        }
    }
}
