using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using VehiChoice.DTO;
using VehiChoice.Service.Interface;
using System.Security.Claims;
using VehiChoice.Models.Entities;
using VehiChoice.Service.Interface;
using VehiChoice.Service.Interface;

namespace VehiChoice.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IWalletService _walletService;
        private readonly IPaymentService _paymentService;
        private readonly ICarService _carService;
        private readonly IDepositService _depositService;
        public UserController(IUserService userService, IWalletService walletService, IPaymentService paymentService, ICarService carService, IDepositService depositService)
        {
            _userService = userService;
            _walletService = walletService;
            _paymentService = paymentService;
            _carService = carService;
            _depositService = depositService;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null) 
        {
            ViewBag.ReturnUrl = returnUrl; 
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginRequestModel model, string returnUrl = null)
        {
            var login = _userService.Login(model);
            if (login != null)
            {
                var claims = new List<Claim>
        {
            new Claim (ClaimTypes.NameIdentifier, login.Id),
            new Claim (ClaimTypes.Role, login.Role),
            new Claim (ClaimTypes.Name, login.FirstName),
        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authenticationProperties = new AuthenticationProperties();
                var principal = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);

                if (!string.IsNullOrEmpty(returnUrl)) 
                {
                    return LocalRedirect(returnUrl); 
                }
                else
                {
                    if (login.Role == "SuperAdmin")
                    {
                         TempData["success"] = "SuperAdmin login successfully!";
                        return RedirectToAction("AdminProfile");
                    }
                    else if (login.Role == "Customer")
                    {
                         TempData["success"] = "Customer login successfully!";
                        return RedirectToAction("Index", "Home");
                    }
                    {
                         TempData["success"]= "BranchHead login successfully!";                 
                        return RedirectToAction("Index", "BranchHead");
                    }
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        public IActionResult CustomerProfile()
        {
            var wallet = _walletService.GetById(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = _userService.GetBy(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var userWallet = new User_and_Wallet()
            {
                Wallet = wallet,
                User = user,
            };
            ViewBag.Image = user.ImageReferece;
            return View(userWallet);
        }
        public IActionResult AdminProfile()
        {
            var wallet = _walletService.GetById(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = _userService.GetBy(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var userWallet = new User_and_Wallet()
            {
                Wallet = wallet,
                User = user,
            };
            
            return View(userWallet);
        }
       
        
    }
}
