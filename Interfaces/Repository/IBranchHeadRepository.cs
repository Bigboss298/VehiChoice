using VehiChoice.Models.Enums;
using VehiChoice.Models.Entities;

namespace VehiChoice.Repository.Interface
{
     public interface IBranchHeadRepository
    {
         BranchHead Create(BranchHead branchHead);
         BranchHead Get(Location location);
         BranchHead GetBy(string headName);
         List<BranchHead> GetAll();
         BranchHead Update(string id, BranchHead branchHead);
         string AddMessage(string message);    
    }
}