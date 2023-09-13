

using VehiChoice.DTO;
using VehiChoice.Models.Entities;

namespace VehiChoice.Service.Interface
{
    public interface IDepositService
    {
         BaseResponse Create(CreateDepositRequestModel model);
         Deposit Get(string referenceNumber);
         List<Deposit> GetAll();
         //string Update(string id, Deposit deposit);
    }
}