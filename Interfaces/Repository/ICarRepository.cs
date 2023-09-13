
using VehiChoice.Models.Entities;

namespace VehiChoice.Repository.Interface
{
    public interface ICarRepository
    {
         Car Create(Car car);
         Car Get(string uniqueNumber);
         List<Car> GetAll();
         Car Update(string id, Car car);
         
    }
}