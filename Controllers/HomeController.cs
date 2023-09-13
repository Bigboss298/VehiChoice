using Microsoft.AspNetCore.Mvc;
using VehiChoice.Models;
using VehiChoice.Models.Entities;
using VehiChoice.Service.Interface;
using VehiChoice.Service.Interface;
using System.Diagnostics;

namespace VehiChoice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarService _carService;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, ICarService carService, IUserService userService)
        {
            _logger = logger;
            _carService = carService;
            _userService = userService;
        }

        public IActionResult Index()
        {

            var cars = _carService.GetAll();
            var user = _userService.Get(User.Identity.Name);
            if (User.Identity.IsAuthenticated)
            {
                var home = new HomeEntity()
                {
                    Cars = cars,
                    ImageReference = user.ImageReferece,
                };
                return View(home);
            }
            else
            {
                var home = new HomeEntity()
                {
                    Cars = cars,
                };
                return View(home);
            }






        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}