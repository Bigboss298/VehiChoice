using VehiChoice.Models.Enums;
using VehiChoice.Data;
using VehiChoice.Models.Entities;

namespace VehiChoice.Implementations.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly DataContext _dataContext;

        public BranchRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Branch Create(Branch branch)
        {
            _dataContext.Add(branch);
            _dataContext.SaveChanges();
            return branch;
        }

        public Branch Get(Location location)
        {
            return _dataContext.Branchs.FirstOrDefault(x => x.BranchLocation == location);
        }

        public List<Branch> GetAll()
        {
            return _dataContext.Branchs.ToList();
        }

        public Branch Update(string id, Branch branch)
        {
            var branchToUpdate = _dataContext.Branchs.FirstOrDefault(x => x.Id == id);
            if(branchToUpdate != null)
            {
                _dataContext.SaveChanges();
                return branchToUpdate;
            }
            return null;
        }
    }
}
