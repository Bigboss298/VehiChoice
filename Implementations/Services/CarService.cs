using Microsoft.Extensions.Hosting;
using VehiChoice.Models.Enums;
using VehiChoice.DTO;
using VehiChoice.Models.Entities;
using VehiChoice.Service.Interface;
using VehiChoice.Repository.Interface;
using System.Security.Claims;

namespace VehiChoice.Implementations.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CarService(ICarRepository carRepository, IWebHostEnvironment webHostEnvironment)
        {
            _carRepository = carRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public BaseResponse Create(CreateCarRequestModel model)
        {
            if(model == null)
            {

                return new BaseResponse()
                {
                    Status = false,
                    Message = "Model is null",
                };
            }
            if (model.CarImage is null || model.CarImage.Length <= 0)
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "Please select a profile picture",
                };
            }

            var acceptableExtension = new List<string>() { ".jpg", ".jpeg", ".png", ".dnb" };
            var fileExtension = Path.GetExtension(model.CarImage.FileName);
            if (!acceptableExtension.Contains(fileExtension))
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "File format not suppported, please upload a picture"
                };
            }
            Car car = new()
            {
                Brand = model.Brand,
                Name = model.Name,
                Model = model.Model,
                Color = model.Color,
                Price = model.Price,
                Status = Status.Unsold,
                BranchLocation = model.ManagerLocation,
                CarImageReference = ManageUploadOfProfilePictures(model.CarImage),
            };
            _carRepository.Create(car);
            return new BaseResponse
            {
                Status = true,
                Message = "Car created successfully",
            };
        }

        public Car Get(string uniqueNumber)
        {
            var car = _carRepository.Get(uniqueNumber);
            if(car == null)
            {
                return null;
            }
            return car;
        }

        public List<Car> GetAll()
        {
            var car = _carRepository.GetAll();  
            if(car.Count == 0)
            {
                return null;
            }
            return car.Select(x => new Car
            {
                Brand = x.Brand,
                Name = x.Name,
                Color = x.Color,
                Model = x.Model,
                UniqueNumber = x.UniqueNumber,
                Price = x.Price,
                Status = x.Status,
                BranchLocation = x.BranchLocation,
                CarImageReference = x.CarImageReference,
           }).ToList();
        }

        public Car Update(string id, Car car)
        {
            var carToUpdate = _carRepository.Update(id, car);
            if( carToUpdate != null ) 
            {
                return carToUpdate;
            }
            return null;
        }
        private string ManageUploadOfProfilePictures(IFormFile picture)
        {
            var uploadsFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "ProfilePictures");
            Directory.CreateDirectory(uploadsFolderPath);
            string fileName = Guid.NewGuid() + picture.FileName;
            string photoPath = Path.Combine(uploadsFolderPath, fileName);

            using (var fileStream = new FileStream(photoPath, FileMode.Create))
            {
                picture.CopyTo(fileStream);
            }

            return fileName;
        }
    }
}
