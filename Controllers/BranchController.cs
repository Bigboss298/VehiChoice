using Microsoft.AspNetCore.Mvc;
using VehiChoice.DTO;
using VehiChoice.Models.Entities;
using VehiChoice.Service.Interface;

namespace VehiChoice.Controllers
{
    public class BranchController : Controller
    {
        private readonly IBranchService _branchService;
        private readonly IUserService _userService;
        public BranchController(IBranchService branchService, IUserService userService)
        {
            _branchService = branchService;
            _userService = userService;
        }
        public IActionResult CreateBranch(CreateBranchRequestModel model)
        {
            if (HttpContext.Request.Method == "POST")
            {
                var branchToCreate = _branchService.Create(model);
                if (branchToCreate.Status == true)
                {
                    
                    return RedirectToAction("Branchs", "Branch");
                }
                return View(model);
            }
            return View(model);
        }
        public IActionResult Branchs()
        {
            var branchs = _branchService.GetAll();
            return View(branchs);
        }
    }
}
