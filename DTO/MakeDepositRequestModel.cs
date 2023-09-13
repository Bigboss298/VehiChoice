namespace VehiChoice.DTO
{
    public class MakeDepositRequestModel
    {
        public string WalletNumber { get; set; }
        public double Amount { get; set; }
        public int Pin { get; set; }
    }
}
