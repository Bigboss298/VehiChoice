

using VehiChoice.DTO;
using VehiChoice.Models.Entities;

namespace VehiChoice.Service.Interface
{
    public interface IUserService
    {
        // User Create(User user);
        User Get(string firstName);
        List<User> GetAll();
        User Update(string id, User user);
        User GetBy(string id);
        User Login(LoginRequestModel model);
    }
}