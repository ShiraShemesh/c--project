using Dal;
using DalApi;
using DO;
using System.Reflection;
using Tools;

namespace dalList;
internal class CustomerImplementation : ICustomer
{
    public int Create(Customer item)
    {
        int itemIndex = DataSource.Customers.FindIndex(p => p.CustomerId == item.CustomerId);
        if (itemIndex > 0)
            throw new IdExisteFoundExcptions($"Customer with Id {item.CustomerId} exists");
        DataSource.Customers.Add(item);
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                              MethodBase.GetCurrentMethod().Name,
                              $"Customer with Id: {item.CustomerId} created.");
        return item.CustomerId;
    }
    public Customer? Read(Func<Customer, bool> filter)
    {
        var first = from customer in DataSource.Customers
                    where filter(customer)
                    select customer;
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                              MethodBase.GetCurrentMethod().Name,
                              $"Customer readed with filter func .");
        return first.FirstOrDefault();

    }
    public Customer? Read(int id)
    {
        Customer item = DataSource.Customers.Find(p => p?.CustomerId == id);
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                              MethodBase.GetCurrentMethod().Name,
                              $"Customer read by id: {id}.");
        return item;

    }
    public List<Customer?> ReadAll(Func<Customer, bool>? filter = null)
    {
        if (filter == null)
            return DataSource.Customers.ToList();
        var dataFilter = from customer in DataSource.Customers
                         where filter(customer)
                         select customer;
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                              MethodBase.GetCurrentMethod().Name,
                              $"Customer readed all.");
        return dataFilter.ToList();
    }

    public void Update(Customer item)
    {
        Delete(item.CustomerId);
        Create(item);
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                              MethodBase.GetCurrentMethod().Name,
                              $"Customer by id: {item.CustomerId} , update .");
    }

    public void Delete(int id)
    {
        var found = DataSource.Customers
            .Select((c, idx) => new { c, idx })
            .Where(x => x.c?.CustomerId == id)
            .FirstOrDefault();

        if (found is null)
            throw new IdNotFoundExcptions($"Customer with Id {id} not found.");
        DataSource.Customers.RemoveAt(found.idx);
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                              MethodBase.GetCurrentMethod().Name,
                              $"Customer by id: {id} delete .");
    }


}