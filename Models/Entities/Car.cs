using VehiChoice.Models.Enums;

namespace VehiChoice.Models.Entities
{
    public class Car : BaseEntity
    {
        public string Brand{get; set;}
        public string Name{get; set;}
        public string Color{get; set;}
        public string Model{get; set;}
        public string UniqueNumber { get; set; } = GenerateUniqueNumber();      
        public double Price{get; set;}
        public Status Status{get; set;}
        public Location BranchLocation{get; set;}
        public string CarImageReference { get; set;} 
        public List<BranchCars> BranchCars{get; set;}

        public static string GenerateUniqueNumber()
        {
            Random rand =new();
            return $"UIN/NBV/{rand.Next(00, 100).ToString() + rand.Next(000, 999).ToString()}";
        }
        
    }
}