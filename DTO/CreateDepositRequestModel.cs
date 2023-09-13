namespace VehiChoice.DTO
{
    public class CreateDepositRequestModel
    {
        public string WalletNumber { get; set; }
        public int WalletPin { get; set; }
        public double Amount { get; set; }
    }
}
