using Microsoft.AspNetCore.Mvc;
using VehiChoice.DTO;
using VehiChoice.Service.Interface;

namespace VehiChoice.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public IActionResult CreateCustomer(CreateCustomerRequestModel model)
        {
            if (HttpContext.Request.Method == "POST")
            {
                var customerModel = _customerService.Create(model);

                if (customerModel.Status == true)
                {
                    return RedirectToAction("Login", "User");
                }
                return View();
            }
            return View();
        }

    }

}

