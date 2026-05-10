
using BlApi;
using BO;

namespace BlImplementation
{
    internal class CustomerImplementation : ICustomer
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public void Create(Customer customer)
        {
            _dal.Customer.Create(customer.convert());
        }

        public void Delete(int id)
        {
            _dal.Customer.Delete(id);
        }

        public bool CustomerExist(int id)
        {
            var customer = _dal.Customer.Read(id);
            return customer != null;
        }

        public Customer? Read(int id)
        {
            var customer = _dal.Customer.Read(id);
            return customer?.convert();
        }
        public Customer? Read(Func<Customer, bool> filter)
        {
            var allCustomer = _dal.Customer.ReadAll();
            var boCustomer = allCustomer.Select(c => c.convert());
            return boCustomer.FirstOrDefault(filter);
        }
        public List<Customer?> ReadAll(Func<Customer, bool>? filter = null)
        {
            var allCustomer = _dal.Customer.ReadAll();
            var boCustomer = allCustomer.Select(c => c.convert()).ToList();
            return boCustomer;
        }

        public void Update(Customer customer)
        {
            _dal.Customer.Update(customer.convert());

        }

    }
}