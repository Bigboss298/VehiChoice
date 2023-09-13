using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using VehiChoice.Models.Enums;
using VehiChoice.Service.Interface;
using VehiChoice.DTO;
using VehiChoice.Implementations.Services;
using VehiChoice.Models.Entities;
using VehiChoice.Service.Interface;
using VehiChoice.Service.Interface;
using System.Security.Claims;

namespace VehiChoice.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IUserService _userService;
        private readonly ICarService _carService;
        private readonly IWalletService _walletService;
        public PaymentController(IPaymentService paymentService, IUserService userService,ICarService carService, IWalletService walletService)
        {
            _paymentService = paymentService;
            _userService = userService;
            _carService = carService;
            _walletService = walletService;
        }


        [HttpGet]
        public IActionResult MakePayment([FromQuery] string uin, [FromQuery] double amount, [FromQuery] VehiChoice.Models.Enums.Location branch)
        {
            var user = _userService.Get(User.Identity.Name).ImageReferece;
            var model = new CreatePaymentRequestModel()
            {
                BeneficiaryWalletNumber = "",
                BenefactorWalletNumber = "",
                Amount = amount,
                WalletPin = 0,
                UniqueNumber = uin, 
                BranchLocation = branch,
            };
            ViewBag.Image = user;
            return View("MakePayment", model);
        }
        [HttpPost]
        public IActionResult MakePayment(CreatePaymentRequestModel carToBeSold)
        {
            var user = _userService.Get(User.Identity.Name);
            var car = _carService.Get(carToBeSold.UniqueNumber);

            carToBeSold.BenefactorWalletNumber = _walletService.GetById(user.Id).WalletNumber;
            carToBeSold.BeneficiaryWalletNumber = "WALTID/NBV/001";
            carToBeSold.Amount = car.Price;
            carToBeSold.BranchLocation = car.BranchLocation;

            var makePayment = _paymentService.Create(carToBeSold);
            if(makePayment.Status)
            {
                TempData["showModal"] = "true";
                TempData["success"] = "Payment Sucessful";
                return RedirectToAction("PaymentSuccesful");
            }
            TempData["success"] = makePayment.Message;
            return RedirectToAction("AllCars", "Car");
        }

        public IActionResult PaymentSuccesful()
        { return View(); }
    }
}

