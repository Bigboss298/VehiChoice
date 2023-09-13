using VehiChoice.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehiChoice.DTO
{
    public class CreateCustomerRequestModel 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Location Location { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public string Password { get; set; }
        public int WalletPin { get; set; }
        [NotMapped]
        public IFormFile FormFile { get; set; }
    }
}
