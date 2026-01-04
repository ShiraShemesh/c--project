using Dal;
using DalApi;
using DO;

namespace dalList;
internal class CustomerImplementation : ICustomer
{
    public int Create(Customer item)
    {
        int itemIndex = DataSource.Customers.FindIndex(p => p.CustomerId == item.CustomerId);
        if (itemIndex > 0)
            throw new IdExisteFoundExcptions($"Customer with Id {item.CustomerId} exists");
        DataSource.Customers.Add(item);
        return item.CustomerId;
    }

    public Customer? Read(int id)
    {
        Customer item = DataSource.Customers.Find(p => p?.CustomerId == id);
        return item;
    }

    public List<Customer?> ReadAll()
    {
        return DataSource.Customers;
    }

    public void Update(Customer item)
    {
        int itemIndex = DataSource.Customers.FindIndex(p => p?.CustomerId == item.CustomerId);
        if (itemIndex == -1)
            throw new IdNotFoundExcptions($"Customer with Id {item.CustomerId} not found.");
        DataSource.Customers[itemIndex] = item;
    }

    public void Delete(int id)
    {
        int itemIndex = DataSource.Customers.FindIndex(p => p?.CustomerId == id);
        if (itemIndex == -1)
            throw new IdNotFoundExcptions($"Customer with Id {id} not found.");
        DataSource.Customers.RemoveAt(itemIndex);
    }


}

