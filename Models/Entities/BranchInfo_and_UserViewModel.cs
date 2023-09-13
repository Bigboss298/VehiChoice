using VehiChoice.DTO;

namespace VehiChoice.Models.Entities
{
    public class BranchInfo_and_UserViewModel
    {
        public User User { get; set; }
        public int SoldCars { get; set; }
        public int UnsoldCars { get; set; }
        public int Customers { get; set; }
        public int Cars { get; set; }
    }
}
