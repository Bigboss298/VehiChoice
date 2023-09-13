using VehiChoice.Models.Enums;
using VehiChoice.Data;
using VehiChoice.Models.Entities;
using VehiChoice.Repository.Interface;
using ZstdSharp;
using ZstdSharp.Unsafe;

namespace VehiChoice.Implementations.Repositories
{
    public class BranchHeadRepository : IBranchHeadRepository
    {
        private readonly DataContext _dataContext;

        public BranchHeadRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public string AddMessage(string message)
        {
           throw new NotImplementedException();
        }

        public BranchHead Create(BranchHead branchHead)
        {
            _dataContext.Add(branchHead);
            _dataContext.SaveChanges();
            return branchHead;
        }

        public BranchHead Get(Location location)
        {
            return _dataContext.BranchHeads.FirstOrDefault(x => x.BranchLocation == location);
        }

        public List<BranchHead> GetAll()
        {
            return _dataContext.BranchHeads.ToList();
        }

        public BranchHead GetBy(string headName)
        {
            return _dataContext.BranchHeads.FirstOrDefault(x => x.Name == headName);
        }

        public BranchHead Update(string id, BranchHead branchHead)
        {
            var branchHeadToUpdate = _dataContext.BranchHeads.FirstOrDefault(x => x.Id == id);
            if (branchHeadToUpdate != null)
            {
                _dataContext.Update(branchHeadToUpdate);
                _dataContext.SaveChanges();
                return branchHead;
            }
            return null;
        }
    }
}
