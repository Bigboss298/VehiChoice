using VehiChoice.Models.Enums;
using VehiChoice.Service.Interface;
using VehiChoice.DTO;
using VehiChoice.Implementations.Repositories;
using VehiChoice.Models.Entities;
using VehiChoice.Repository.Interface;

namespace VehiChoice.Implementations.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IWalletRepository _walletRepository;
        private readonly ICarRepository _carRepository;
        public PaymentService(IPaymentRepository paymentRepository, IWalletRepository walletRepository, ICarRepository carRepository)
        {
            _paymentRepository = paymentRepository;
            _walletRepository = walletRepository;
            _carRepository = carRepository;
        }

        public BaseResponse Create(CreatePaymentRequestModel model)
        {
            var user = _walletRepository.Get(model.BenefactorWalletNumber);
            var admin = _walletRepository.Get(model.BeneficiaryWalletNumber);
            var car = _carRepository.Get(model.UniqueNumber);
            if(model == null)
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "Model is null,"
                };
            }
            if(user == null)
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "user account is null",
                };
            }
            if(admin == null)
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "admin account is null",
                };
            }
            if(car.Status == Status.Sold)
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "car has been sold"
                };
            }

            Payment payment = new()
            {
                BeneficiaryWalletNumber = model.BeneficiaryWalletNumber,
                BenefactorWalletNumber = model.BenefactorWalletNumber,
                Pin = model.WalletPin,
                Amount = model.Amount,
            };
            user.WalletBalance -= model.Amount;
            admin.WalletBalance += model.Amount;
            car.Status = Status.Sold;

            _walletRepository.Update(user.Id, user);
            _walletRepository.Update(admin.Id, admin);
            _carRepository.Update(car.Id, car);
           _paymentRepository.Create(payment);
                return new BaseResponse
                {
                    Status = true,
                    Message = "Payment made Successfully!!!",
                };
        }

        public Payment Get(string referenceNumber)
        {
            var payment = _paymentRepository.Get(referenceNumber);
            if(payment == null)
            {
                return null;
            }
            return payment;
        }

        public List<Payment> GetAll()
        {
            var payments = _paymentRepository.GetAll();
            if(payments.Count > 0)
            {
                return payments.Select(x => new Payment
                {
                    BenefactorWalletNumber = x.BenefactorWalletNumber,
                    BeneficiaryWalletNumber = x.BeneficiaryWalletNumber,
                    Pin = x.Pin,
                    Amount = x.Amount,
                    ReferenceNumber = x.ReferenceNumber,
                }).ToList();
            }
            return null;
        }

        public Payment Update(string id, Payment payment)
        {
            var paymentToUpdate = _paymentRepository.Update(id, payment);
            if (paymentToUpdate == null)
            {
                return null;
            }
            return paymentToUpdate;
        }
    }
}
