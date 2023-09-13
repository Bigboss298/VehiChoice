using VehiChoice.DTO;
using VehiChoice.Models.Entities;
using VehiChoice.Repository.Interface;
using VehiChoice.Service.Interface;

namespace VehiChoice.Implementations.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User Get(string firstName)
        {
            var user = _userRepository.Get(firstName);
            if(user == null)
            {
                return null;
            }
            return user;
        }

        public List<User> GetAll()
        {
                var users = _userRepository.GetAll();
            if(users.Count == 0)
            {
                return null;
            }
            return users.Select(x => new User
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Location = x.Location,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Role = x.Role,
                Gender = x.Gender,
                WalletType = x.WalletType,
                Password = x.Password,
            }).ToList();
        }

        public User GetBy(string id)
        {
            var user = _userRepository.GetBy(id);
            if(user == null)
            {
                return null;
            }
            return user;
        }

        public User Login(LoginRequestModel model)
        {
            var loginUser = _userRepository.Login(model);
            if(loginUser != null)
            {
                return loginUser;
            }
            return null;
        }

        public User Update(string id, User user)
        {
            var userToUpdate = _userRepository.Update(id, user);
            if(userToUpdate == null)
            {
                return null;
            }
            return userToUpdate;
        }
    }
}
