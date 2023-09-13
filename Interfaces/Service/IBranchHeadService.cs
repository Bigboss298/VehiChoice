using VehiChoice.Models.Enums;
using VehiChoice.Models.Entities;

namespace VehiChoice.Service.Interface
{
    public interface IBranchHeadService
    {
         BranchHead Get(Location location);
         List<BranchHead> GetAll();
         BranchHead Update(string id, BranchHead branchHead);
         //BranchHead GetMessage(string name);
         //string Create(BranchHead branchHead);
        BranchHead GetBy(string headName);
        //string AddMessage(string message);
    }
}