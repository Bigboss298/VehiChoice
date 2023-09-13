using VehiChoice.Models.Enums;

namespace VehiChoice.DTO
{
    public class CreatePaymentRequestModel
    {
        public string BeneficiaryWalletNumber { get; set; }
        public string BenefactorWalletNumber { get; set; }
        public double Amount { get; set; }
        public Location BranchLocation { get; set; }
        public int WalletPin { get; set; }
        public string UniqueNumber { get; set; }
    }
}
