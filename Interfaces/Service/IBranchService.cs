using VehiChoice.Models.Enums;
using VehiChoice.Service.Interface;
using VehiChoice.DTO;
using VehiChoice.Models.Entities;

namespace VehiChoice.Service.Interface
{
    public interface IBranchService
    {
         BaseResponse Create(CreateBranchRequestModel model);
         Branch Get(Location location);
         List<Branch> GetAll();
         Branch Update(string id, Branch branch);
    }
}