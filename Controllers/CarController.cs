using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehiChoice.Models.Enums;
using VehiChoice.DTO;
using VehiChoice.Models.Entities;
using VehiChoice.Service.Interface;
using VehiChoice.Service.Interface;

namespace VehiChoice.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly IUserService _userService;
        public CarController(ICarService carService, IUserService userService)
        {
            _carService = carService;
            _userService = userService;
        }
        [Authorize(Roles = "BranchHead")]
        public IActionResult Create(CreateCarRequestModel newCar)
        {
            var loc = _userService.Get(User.Identity?.Name).Location;
            newCar.ManagerLocation = loc;
            if(HttpContext.Request.Method == "POST")
            {
                var car = _carService.Create(newCar);
                if(car.Status == true)
                {
                    return RedirectToAction("Index", "BranchHead");
                }            
                return View(newCar);
            }
            return View(newCar);
        }
        [Authorize]
        public IActionResult AllCars()
        {
            var user = _userService.Get(User.Identity?.Name);
            ViewBag.Image = user.ImageReferece;
            ViewBag.Role = user.Role;
            
            IEnumerable<Car> cars = _carService.GetAll();
            return View(cars); 
        }
       
        //public IActionResult Purchase()
        //{

        //}
        //[Authorize]
        //public IActionResult UpdateCar(string uniqueNumber)
        //{
        //    var carToBeUpdated = _carService.Get(uniqueNumber);
        //    Car car = new()
        //    {
        //        Id = carToBeUpdated.Id,
        //        Brand = carToBeUpdated.Brand,
        //        Name = carToBeUpdated.Name,
        //        Color = carToBeUpdated.Color,
        //        Model = carToBeUpdated.Model,
        //        UniqueNumber = carToBeUpdated.UniqueNumber,
        //        Price = carToBeUpdated.Price,
        //        Status = Status.Sold,
        //        BranchLocation = carToBeUpdated.BranchLocation,
        //    };
        //    _carService.Update(carToBeUpdated.Id, car);
        //    return RedirectToAction("CustomerIndex", "User");

        //}
    }
}
