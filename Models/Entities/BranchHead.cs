using VehiChoice.Models.Enums;

namespace VehiChoice.Models.Entities
{
    public class BranchHead : BaseEntity
    {
        public Location BranchLocation{get; set;}
        public string Name{get; set;}
        public string Message{get; set;} = string.Empty;
    }
}