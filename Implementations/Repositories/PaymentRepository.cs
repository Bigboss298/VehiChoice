using VehiChoice.Data;
using VehiChoice.Models.Entities;
using VehiChoice.Repository.Interface;

namespace VehiChoice.Implementations.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DataContext _dataContext;

        public PaymentRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Payment Create(Payment payment)
        {
            _dataContext.Add(payment);
            _dataContext.SaveChanges();
            return payment;
        }

        public Payment Get(string referenceNumber)
        {
            return _dataContext.Payments.First(x => x.ReferenceNumber == referenceNumber);
        }

        public List<Payment> GetAll()
        {
            return _dataContext.Payments.ToList();
        }

        public Payment Update(string id, Payment payment)
        {
            var paymentToUpdate = _dataContext.Payments.FirstOrDefault(x => x.Id == id);
            if(paymentToUpdate != null) 
            {
                _dataContext.SaveChanges();
                return payment;
            }
            return null;
        }
    }
}
