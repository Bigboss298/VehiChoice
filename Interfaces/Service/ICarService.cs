
using VehiChoice.DTO;
using VehiChoice.Models.Entities;

namespace VehiChoice.Service.Interface
{
    public interface ICarService
    {
         BaseResponse Create(CreateCarRequestModel model);
         Car Get(string uniqueNumber);
         List<Car> GetAll();
         Car Update(string id, Car car);
    }
}