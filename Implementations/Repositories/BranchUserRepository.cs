using VehiChoice.Data;
using VehiChoice.Models.Entities;
using VehiChoice.Repository.Interface;

namespace VehiChoice.Implementations.Repositories
{
    public class BranchUserRepository : IBranchUserRepository
    {
        private readonly DataContext _dataContext;

        public BranchUserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public BranchUsers Create(BranchUsers branchUsers)
        {
            _dataContext.Add(branchUsers);
            _dataContext.SaveChanges();
            return branchUsers;
        }
    }
}
