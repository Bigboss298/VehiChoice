using VehiChoice.Models.Entities;

namespace VehiChoice.Repository.Interface
{
    public interface ICustomerRepository
    {
         Customer Create(Customer customer);
         Customer Get(string email);
         List<Customer> GetAll();
         Customer Update(string id, Customer customer);
    }
}