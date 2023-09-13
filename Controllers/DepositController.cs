using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VehiChoice.DTO;
using VehiChoice.Implementations.Services;
using VehiChoice.Models.Entities;
using VehiChoice.Service.Interface;
using System.Security.Claims;

namespace VehiChoice.Controllers
{
    

    public class DepositController : Controller
    {
        private readonly IWalletService _walletService;
        private readonly IDepositService _depositService;
        private readonly IUserService _userService;
        public DepositController(IWalletService walletService, IDepositService depositService, IUserService userService)
        {
            _walletService = walletService;
            _depositService = depositService;
            _userService = userService;
        }

        public IActionResult MakeDeposit(CreateDepositRequestModel depoToMake)
        {

                var user = _userService.Get(User.Identity?.Name);
                var wallet = _walletService.GetById(user.Id);
                depoToMake.WalletNumber = wallet.WalletNumber;
            if (HttpContext.Request.Method == "POST")
            {
 
                var depo = _depositService.Create(depoToMake);
                if (depo.Status == true)
                {
                    ViewBag.Message = depo.Message;
                    return RedirectToAction("customerProfile", "User");
                }
                ViewBag.Image = user.ImageReferece;
                return View();
            }
            ViewBag.Image = user.ImageReferece;
            return View();
        }
    }
}
