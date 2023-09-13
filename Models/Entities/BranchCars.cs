namespace VehiChoice.Models.Entities
{ 
    public class BranchCars : BaseEntity
    {
        public string CarId{get; set;}
        public Car Car{get; set;}
        public string BranchId{get; set;}
        public Branch Branch{get; set;}
    }
}