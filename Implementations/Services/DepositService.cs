using VehiChoice.DTO;
using VehiChoice.Models.Entities;
using VehiChoice.Repository.Interface;
using VehiChoice.Service.Interface;

namespace VehiChoice.Implementations.Services
{
    public class DepositService : IDepositService
    {
        private readonly IDepositRepository _depositRepository;
        private readonly IWalletRepository _walletRepository;
        //private readonly IHttpContextAccessor _httpContextAccessor;
        public DepositService(IDepositRepository depositRepository, IWalletRepository walletRepository /*IHttpContextAccessor httpContextAccessor*/)
        {
            _depositRepository = depositRepository;
            _walletRepository = walletRepository;
            //_httpContextAccessor = httpContextAccessor;
        }

        public BaseResponse Create(CreateDepositRequestModel model)
        {
            var walt = _walletRepository.Get(model.WalletNumber);
            if (model == null)
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "Model is Null",
                };
            }
            if(walt == null)
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "Wallet Number is null",
                };
            }
            Deposit deposit = new()
            {
                WalletNumber = model.WalletNumber,
                WalletPin = model.WalletPin,
                Amount = model.Amount,
            };

            walt.WalletBalance += model.Amount;
            _walletRepository.Update(walt.Id, walt);
            _depositRepository.Create(deposit);
            return new BaseResponse
            {
                Status = true,
                Message = "Deposit made sucesfully!",
            };
        }

        public Deposit Get(string referenceNumber)
        {
            var deposit = _depositRepository.Get(referenceNumber);
            if(deposit == null)
            {
                return null;
            }
            return deposit;
        }

        public List<Deposit> GetAll()
        {

            var deposit = _depositRepository.GetAll();
            if(deposit.Count > 0)
            {
                return deposit.Select(x => new Deposit
                {
                    WalletNumber = x.WalletNumber,
                    WalletPin = x.WalletPin,
                    Amount = x.Amount,
                    ReferenceNumber = x.ReferenceNumber,
                }).ToList();
            }
            return null;
        }
    }
}
