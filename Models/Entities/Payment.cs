namespace VehiChoice.Models.Entities
{
    public class Payment : BaseEntity
    {
        public string BeneficiaryWalletNumber { get; set; }
        public string BenefactorWalletNumber { get; set; }
        public int Pin { get; set; }
        public double Amount { get; set; }
        public string ReferenceNumber { get; set; } = GeneratePaymentReferenceNumber();

        public static string GeneratePaymentReferenceNumber()
        {
            Random rand = new Random();
            return $"NBV/REF/{rand.Next(00, 100).ToString()}";
        }
    }
}