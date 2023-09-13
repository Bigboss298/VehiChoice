using VehiChoice.Models.Enums;

namespace VehiChoice.Models.Entities
{
    public class Customer : BaseEntity
    {
     //    public string UserId{get; set;}
        public string UserEmail{get; set;}
        public List<Car> Cars{get; set;}
        public List<Deposit> Deposits{get; set;}
        public List<Payment> Payments{get; set;}
    }
}