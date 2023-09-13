using VehiChoice.Models.Enums;

namespace VehiChoice.Models.Entities
{
    public class Wallet : BaseEntity
    {
        public string WalletNumber { get; set; } = GenerateWalletNumber();
        public string WalletName{get; set;}
        public int WalletPin{get; set;}
        public WalletType WalletType{get; set;}
        public Location Location{get; set; }
        public double WalletBalance { get; set; } 

     public static string GenerateWalletNumber()
          {
               Random random = new Random();
               return $"WALTID/NBV/00"+random.Next(002, 100);
          }
}

}