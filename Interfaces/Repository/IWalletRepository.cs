using VehiChoice.Models.Entities;

namespace VehiChoice.Repository.Interface
{
    public interface IWalletRepository
    {
         Wallet Create(Wallet wallet);
         Wallet Get(string walletNumber);
         List<Wallet> GetAll();
         Wallet Update(string id, Wallet wallet);
         Wallet GetBy(string walletName);
        Wallet GetById(string id);
    }
}