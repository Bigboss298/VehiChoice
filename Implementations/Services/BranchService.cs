using Microsoft.Extensions.Hosting;
using VehiChoice.Models.Enums;
using VehiChoice.DTO;
using VehiChoice.Models.Entities;
using VehiChoice.Repository.Interface;
using VehiChoice.Service.Interface;

namespace VehiChoice.Implementations.Services
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IBranchHeadRepository _branchHeadRepository;
        private readonly IUserRepository _userRepository;
        private readonly IWebHostEnvironment _hostEnvironment;
        public BranchService(IBranchRepository branchRepository, IBranchHeadRepository branchHeadRepository, IUserRepository userRepository, IWebHostEnvironment hostEnvironment)
        {
            _branchHeadRepository = branchHeadRepository;
            _branchRepository = branchRepository;
            _userRepository = userRepository;
            _hostEnvironment = hostEnvironment;
        }
        public BaseResponse Create(CreateBranchRequestModel model)
        {
            if (model == null)
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "Model is null",
                };
            }
            var getBranch = _branchRepository.Get(model.BranchLocation);
            if (getBranch != null)
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "Branch already exits",
                };
            }
            Branch branch = new()
            {
                BranchLocation = model.BranchLocation,
                BranchHeadName = $"{model.FirstName} {model.LastName}",
                Name = $"{model.BranchLocation} Branch",
            };
            var getUser = _userRepository.Get(model.FirstName);
            if (getUser != null)
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "User already exits",
                };
            }
            if (model.BranchHeadFile is null || model.BranchHeadFile.Length <= 0)
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "Please select a profile image"
                };
            }
            var acceptableExtension = new List<string>() { ".jpg", ".jpeg", ".png", ".dnb" };
            var fileExtension = Path.GetExtension(model.BranchHeadFile.FileName);
            if (!acceptableExtension.Contains(fileExtension))
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "File format not suppported, please upload a picture"
                };
            }
            BranchHead branchHead = new()
            {
                BranchLocation = model.BranchLocation,
                Name = $"{model.FirstName} {model.LastName}",
                //Message = model.Message,
            };
            User user = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Location = model.BranchLocation,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Role = "BranchHead",
                Gender = model.Gender,
                WalletType = WalletType.BranchHead,
                Password = model.Password,
                ImageReferece = ManageUploadOfProfilePictures(model.BranchHeadFile),
            };
            _branchHeadRepository.Create(branchHead);
            _branchRepository.Create(branch);
            _userRepository.Create(user);
            return new BaseResponse
            {
                Status = true,
                Message = "Branch successfully created"
            };

        }

        public Branch Get(Location location)
        {
            var branch = _branchRepository.Get(location);
            if (branch == null)
            {
                return null;
            }
            return branch;
        }

        public List<Branch> GetAll()
        {
            var branch = _branchRepository.GetAll();
            if (branch.Count == 0)
            {
                return null;
            }
            return branch.Select(x => new Branch
            {
                BranchLocation = x.BranchLocation,
                BranchHeadName = x.BranchHeadName,
                Name = x.Name,
            }).ToList();
        }

        public Branch Update(string id, Branch branch)
        {
            var branchToUpdate = _branchRepository.Update(id, branch);
            if (branchToUpdate != null)
            {
                return branchToUpdate;
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
