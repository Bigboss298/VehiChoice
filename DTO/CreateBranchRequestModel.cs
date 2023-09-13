using VehiChoice.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehiChoice.DTO
{
    public class CreateBranchRequestModel
    {
        public Location BranchLocation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [NotMapped]
        public IFormFile BranchHeadFile { get; set; }
    }
}
