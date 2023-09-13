using VehiChoice.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehiChoice.DTO
{
    public class CreateCarRequestModel
    {
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public Location ManagerLocation { get; set; }
        [NotMapped]
        public IFormFile CarImage { get; set; } 
    }
}
