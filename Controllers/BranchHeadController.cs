using Microsoft.AspNetCore.Mvc;
using VehiChoice.Models.Enums;
using VehiChoice.DTO;
using VehiChoice.Models.Entities;
using VehiChoice.Service.Interface;
using VehiChoice.Service.Interface;
using System.Security.Cryptography.X509Certificates;

namespace VehiChoice.Controllers
{
    public class BranchHeadController : Controller
    {
        private readonly IUserService _userService;
        private readonly IBranchService _branchService;
        private readonly ICarService _carService;
        private readonly ICustomerService _customerService;
        public BranchHeadController(IUserService userService, IBranchService branchService, ICarService carService, ICustomerService customerService)
        {
            _userService = userService;
            _branchService = branchService;
            _carService = carService;
            _customerService = customerService;

        }

        public IActionResult Index()
        {
            var user = _userService.Get(User.Identity.Name);
            User bUser = new()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Location = user.Location,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                Gender = user.Gender,
                WalletType = user.WalletType,
                Password = user.Password,
                ImageReferece = user.ImageReferece,
            };
            var car = _carService.GetAll();
            var customer = _userService.GetAll();

             List<Car> soldList = new();
             List<Car> unSoldList = new();
             List<Car> branchCars = new();

            List<User> customerList = new();

            foreach(var item in car)
            {
                if(item.BranchLocation == user.Location && item.Status == Status.Sold)
                {
                    soldList.Add(item);
                }
                if(item.BranchLocation == user.Location && item.Status == Status.Unsold)
                {
                    unSoldList.Add(item);
                }
                if(item.BranchLocation == user.Location)
                {
                    branchCars.Add(item); 
                }
            }

            foreach(var cust in customer)
            {
                if(cust.Location == user.Location && cust.Role == "Customer")
                {
                    customerList.Add(cust);
                }
            }
            var bInfo = new BranchInfo_and_UserViewModel()
            {
                User = bUser,
                SoldCars = soldList.Count,
                UnsoldCars = unSoldList.Count,
                Customers = customerList.Count,
                Cars = branchCars.Count,
            };

            return View(bInfo);
        }
    }
}
