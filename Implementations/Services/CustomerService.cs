using Microsoft.Extensions.Hosting;
using VehiChoice.Models.Enums;
using VehiChoice.DTO;
using VehiChoice.Models.Entities;
using VehiChoice.Repository.Interface;
using VehiChoice.Service.Interface;

namespace VehiChoice.Implementations.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IWalletRepository _walletRepository;
        private readonly IWebHostEnvironment _hostEnvironment;
        public CustomerService(IUserRepository userRepository, IWalletRepository walletRepository, ICustomerRepository customerRepository, IWebHostEnvironment hostEnvironment)
        {
            _userRepository = userRepository;
            _walletRepository = walletRepository;
            _customerRepository = customerRepository;
            _hostEnvironment = hostEnvironment;
        }

        public BaseResponse Create(CreateCustomerRequestModel model)
        {
            if (model == null)
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "Model is Null",
                };
            }
            var customerWithEmail = _userRepository.Get(model.FirstName);
            if(customerWithEmail != null)
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "Email already in use",
                };
            }
            if(model.FormFile is null || model.FormFile.Length <= 0)
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "Please select a profile picture",
                    };
            }

            var acceptableExtension = new List<string>() { ".jpg", ".jpeg", ".png", ".dnb" };
            var fileExtension = Path.GetExtension(model.FormFile.FileName);
            if (!acceptableExtension.Contains(fileExtension))
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "File format not suppported, please upload a picture"
                };
            }

            User user = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Location = model.Location,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Role = "Customer",
                Gender = model.Gender,
                WalletType = WalletType.Customer,
                Password = model.Password,
                ImageReferece = ManageUploadOfProfilePictures(model.FormFile),
            };
            Customer customer = new()
            {
                Id = user.Id,
                UserEmail = model.Email,
            };
            Wallet wallet = new()
            {
                Id = user.Id,
                WalletName = $"{model.FirstName} {model.LastName}",
                WalletPin = model.WalletPin,
                WalletType = WalletType.Customer,
                Location = model.Location,
                WalletBalance = 0.00,
            };
            _userRepository.Create(user);
            _walletRepository.Create(wallet);
            _customerRepository.Create(customer);

            return new BaseResponse
            {
                Status = true,
                Message = "Customer created Successfully!!!",
            };
        }

        public Customer Get(string email)
        {
            var customer = _customerRepository.Get(email);
            if(customer == null)
            {
                return null;
            }
            return customer;
        }

        public List<Customer> GetAll()
        {
            var customer = _customerRepository.GetAll();
            if(customer.Count == 0)
            {
                return null;
            }
            return customer.Select(x => new Customer
            {
                UserEmail = x.UserEmail,
            }).ToList();
        }

        public Customer Update(string id, Customer customer)
        {
            var customerToUpdate = _customerRepository.Update(id, customer);
            if( customerToUpdate != null )
            {
                return customerToUpdate;
            }
            return null;
        }

        private string ManageUploadOfProfilePictures(IFormFile picture)
        {
            var uploadsFolderPath = Path.Combine(_hostEnvironment.WebRootPath, "ProfilePictures");
            Directory.CreateDirectory(uploadsFolderPath);
            string fileName = Guid.NewGuid() + picture.FileName;
            string photoPath = Path.Combine(uploadsFolderPath, fileName);

            using (var fileStream = new FileStream(photoPath, FileMode.Create))
            {
                picture.CopyTo(fileStream);
            }

            return fileName;
        }

    }
}
