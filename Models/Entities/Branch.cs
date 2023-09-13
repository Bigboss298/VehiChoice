using VehiChoice.Models.Enums;

namespace VehiChoice.Models.Entities
{
    public class Branch : BaseEntity
    {
        public Location BranchLocation{get; set;}
        public string BranchHeadName{get; set;}
        public string Name{get; set;}
        public List<BranchCars> BranchCars{get; set;}
        public List<BranchUsers> BranchUsers{get; set;}
    }
}