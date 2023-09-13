using VehiChoice.Data;
using VehiChoice.Models.Entities;
using VehiChoice.Repository.Interface;
using System.Linq;

namespace VehiChoice.Implementations.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly DataContext _dataContext;

        public WalletRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Wallet Create(Wallet wallet)
        {
            _dataContext.Add(wallet);
            _dataContext.SaveChanges();
            return wallet;
        }

        public Wallet Get(string walletNumber)
        {
            //return _dataContext.Wallets.LastOrDefault(x => x.WalletNumber == walletNumber);
            return _dataContext.Wallets.FirstOrDefault(x => x.WalletNumber == walletNumber);
        }

        public List<Wallet> GetAll()
        {
            return _dataContext.Wallets.ToList();
        }

        public Wallet GetBy(string walletName)
        {
            return _dataContext.Wallets.FirstOrDefault(x => x.WalletName == walletName);
        }

        public Wallet GetById(string id)
        {
            var wallet = _dataContext.Wallets.FirstOrDefault(x =>x.Id == id);
            if(wallet == null)
            {
                return null;
            }
            return wallet;
        }

        public Wallet Update(string id, Wallet wallet)
        {
            var walletToUpdated = _dataContext.Wallets.FirstOrDefault(x => x.Id == id); 
            if(walletToUpdated != null)
            {
                _dataContext.Wallets.Update(wallet);
                _dataContext.SaveChanges();
                return wallet;
            }
            return null;
        }
    }
}
