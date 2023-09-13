using VehiChoice.Models.Entities;
using VehiChoice.Service.Interface;
using VehiChoice.Repository.Interface;

namespace VehiChoice.Implementations.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;
        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public Wallet Get(string walletNumber)
        {
            var wallet = _walletRepository.Get(walletNumber);
            if(wallet == null)
            {
                return null;
            }
            return wallet;
        }

        public List<Wallet> GetAll()
        {
            var wallets = _walletRepository.GetAll();   
            if(wallets.Count > 0)
            {
                return wallets.Select(x => new Wallet
                {
                    WalletNumber = x.WalletNumber,
                    WalletName = x.WalletName,  
                    WalletType = x.WalletType,
                    Location = x.Location,
                    WalletBalance = x.WalletBalance,
                }).ToList();
            }
            return null;
        }

        public Wallet GetBy(string walletName)
        {
            var wallet = _walletRepository.GetBy(walletName); 
            if(wallet == null) 
            {
                return null;
            }
            return wallet;
        }

        public Wallet GetById(string id)
        {
            var wallet = _walletRepository.GetById(id);
            if(wallet != null)
            {
                return wallet;
            }
            return null;
        }

        public Wallet Update(string id, Wallet wallet)
        {
            
            var walletToUpdate = _walletRepository.Update(id, wallet);
            if(walletToUpdate == null)
            {
                return null;
            }
            return walletToUpdate;
        }
    }
}
