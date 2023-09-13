using VehiChoice.Data;
using VehiChoice.Models.Entities;
using VehiChoice.Repository.Interface;

namespace VehiChoice.Implementations.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly DataContext _dataContext;

                        public CarRepository(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }
        public Car Create(Car car)
        {
            _dataContext.Add(car);
            _dataContext.SaveChanges();
            return car;
        }

        public Car Get(string uniqueNumber)
        {
            return _dataContext.Cars.FirstOrDefault(x => x.UniqueNumber == uniqueNumber);
        }

        public List<Car> GetAll()
        {
            return _dataContext.Cars.ToList();
        }

        public Car Update(string id, Car car)
        {
            var carToUpdate = _dataContext.Cars.FirstOrDefault(x => x.Id == id);
            if(carToUpdate != null) 
            {
                _dataContext.Cars.Update(car);
                _dataContext.SaveChanges();
                return car;
            }
            return null;
        }
    }
}
