using VehiChoice.DTO;
using VehiChoice.Models.Entities;

namespace VehiChoice.Repository.Interface
{
     public interface IUserRepository
     {

        
          User Create(User user);
          User Login(LoginRequestModel model);
          User Get(string firstName);
          List<User> GetAll();
          User Update(string id, User user);
          User GetBy(string id);
     }
}