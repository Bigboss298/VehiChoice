using VehiChoice.Models.Enums;

namespace VehiChoice.Models.Entities
{
    public class User : BaseEntity
    {
        public string FirstName{get; set;}
        public string LastName{get; set;}
        public Location Location{get; set;}
        public string Email{get; set;}
        public string PhoneNumber{get; set;}
        public string Role{get; set;}
        public Gender Gender{get; set;}
        public WalletType WalletType{get; set;}
        public string Password { get; set;}
        public string ImageReferece { get; set; }
    }
}