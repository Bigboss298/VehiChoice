using VehiChoice.Data;
using VehiChoice.Models.Entities;
using VehiChoice.Repository.Interface;

namespace VehiChoice.Implementations.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _dataContext;

        public CustomerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Customer Create(Customer customer)
        {
            _dataContext.Add(customer);
            _dataContext.SaveChanges();
            return customer;
        }

        public Customer Get(string email)
        {
            return _dataContext.Customers.FirstOrDefault(x => x.UserEmail == email);
        }

        public List<Customer> GetAll()
        {
            return _dataContext.Customers.ToList();
        }

        public Customer Update(string id, Customer customer)
        {
            var customerToUpdate = _dataContext.Customers.FirstOrDefault(x => x.Id == id);
            if(customerToUpdate != null)
            {
                _dataContext.SaveChanges();
                return customer;
            }
            return null;
        }
    }
}
