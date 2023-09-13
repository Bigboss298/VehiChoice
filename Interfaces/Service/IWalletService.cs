
using VehiChoice.Models.Entities;

namespace VehiChoice.Service.Interface
{
    public interface IWalletService
    {
         //Wallet Create(Wallet wallet);
         Wallet Get(string walletNumber);
         List<Wallet> GetAll();
         Wallet Update(string id, Wallet wallet);
         Wallet GetBy(string walletName);
         Wallet GetById(string id);
    }
}