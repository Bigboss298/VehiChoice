using VehiChoice.Data;
using VehiChoice.DTO;
using VehiChoice.Models.Entities;
using VehiChoice.Repository.Interface;

namespace VehiChoice.Implementations.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public User Create(User user)
        {
            _dataContext.Add(user);
            _dataContext.SaveChanges();
            return user;
        }

        public User Get(string firstName)
        {
            return _dataContext.Users.FirstOrDefault(x => x.FirstName == firstName);
        }

        public List<User> GetAll()
        {
            return _dataContext.Users.ToList(); 
        }

        public User GetBy(string id)
        {

            return _dataContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public User Login(LoginRequestModel model)
        {
            return _dataContext.Users.FirstOrDefault(x => x.Password == model.Password && x.Email == model.Email);
        }

        public User Update(string id, User user)
        {
            var userToUpdate = _dataContext.Users.FirstOrDefault(x =>x.Id == id);
            if(userToUpdate != null)
            {
                _dataContext.SaveChanges();
                return userToUpdate;
            }
            return null;
        }
    }
}
