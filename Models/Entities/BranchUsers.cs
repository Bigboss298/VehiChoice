namespace VehiChoice.Models.Entities
{
    public class BranchUsers : BaseEntity
    {
        public string BranchId{get; set;}
        public Branch Branch { get; set;}
        public string UserId{get; set;}
        public User User{get; set;}
    }
}