using VehiChoice.Models.Entities;

namespace VehiChoice.Repository.Interface
{
    public interface IDepositRepository
    {
         Deposit Create(Deposit deposit);
         Deposit Get(string referenceNumber);
         List<Deposit> GetAll();
         Deposit Update(string id, Deposit deposit);
    }
}