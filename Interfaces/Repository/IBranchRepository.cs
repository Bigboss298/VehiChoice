using VehiChoice.Models.Enums;
namespace VehiChoice.Models.Entities
{
    public interface IBranchRepository
    {
         Branch Create(Branch branch);
         Branch Get(Location location);
         List<Branch> GetAll();
         Branch Update(string id, Branch branch);
    }
}