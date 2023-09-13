

using VehiChoice.DTO;
using VehiChoice.Models.Entities;

namespace VehiChoice.Service.Interface
{
    public interface IPaymentService
    {    
         BaseResponse Create(CreatePaymentRequestModel model);
         Payment Get(string referenceNumber);
         List<Payment> GetAll();
         Payment Update(string id, Payment payment);
    }
}