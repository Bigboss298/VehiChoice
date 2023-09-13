using VehiChoice.Models.Enums;
using VehiChoice.Models.Entities;
using VehiChoice.Repository.Interface;
using VehiChoice.Service.Interface;

namespace VehiChoice.Implementations.Services
{
    public class BranchHeadService : IBranchHeadService
    {
        private readonly IBranchHeadRepository _branchHeadRepository;
        public BranchHeadService(IBranchHeadRepository branchHeadRepository)
        {
            _branchHeadRepository = branchHeadRepository;
        }
        public BranchHead Get(Location location)
        {
            var loc = _branchHeadRepository.Get(location);
            if(loc == null)
            {
                return null;
            }
            return loc;
        }

        public List<BranchHead> GetAll()
        {
           var branchHead = _branchHeadRepository.GetAll();
            if(branchHead.Count == 0)
            {
                return null;
            }
            return branchHead.Select(x => new BranchHead
            {
                BranchLocation = x.BranchLocation,
                Name = x.Name,
                Message = x.Message,
            }).ToList();
        }

        public BranchHead GetBy(string headName)
        {
            var brachHead = _branchHeadRepository.GetBy(headName);
            if(brachHead == null)
            {
                return null;
            }
            return brachHead;
        }

        //public BranchHead GetMessage(string name)
        //{
        //    throw new NotImplementedException();
        //}

        public BranchHead Update(string id, BranchHead branchHead)
        {
            var branch = _branchHeadRepository.Update(id, branchHead);
            if(branch == null)
            {
                return null;
            }
            return branch;
                
        }
    }
}
