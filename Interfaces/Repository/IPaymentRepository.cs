using VehiChoice.Models.Entities;

namespace VehiChoice.Repository.Interface
{
    public interface IPaymentRepository
    {
         Payment Create(Payment payment);
         Payment Get(string referenceNumber);
         List<Payment> GetAll();
         Payment Update(string id, Payment payment);
    }
}