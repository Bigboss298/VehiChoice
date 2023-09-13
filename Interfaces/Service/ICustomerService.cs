

using VehiChoice.DTO;
using VehiChoice.Models.Entities;

namespace VehiChoice.Service.Interface
{
    public interface ICustomerService
    {
         BaseResponse Create(CreateCustomerRequestModel model);
         Customer Get(string email);
         List<Customer> GetAll();
         Customer Update(string id, Customer customer);
    }
}