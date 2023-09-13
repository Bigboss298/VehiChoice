namespace VehiChoice.Models.Entities
{
    public class Deposit : BaseEntity
    {
          public string WalletNumber{get; set;}
          public int WalletPin{get; set;}
          public double Amount{get; set;}
        public string ReferenceNumber { get; set; } = GenerateReferenceNumber();

        public static string GenerateReferenceNumber()
        {
            Random rand = new Random();
            return "NBV/REF/" + rand.Next(00, 100).ToString();
        }
    }
   
}