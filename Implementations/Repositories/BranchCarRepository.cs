
using VehiChoice.Data;
using VehiChoice.Interfaces.Repository;
using VehiChoice.Models.Entities;

namespace VehiChoice.Implementations.Repositories
{
    public class BranchCarRepository : IBranchCarServices
    {
        private readonly DataContext _dataContext;
        public BranchCarRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public BranchCars Create(BranchCars branchCars)
        {
            _dataContext.Add(branchCars);
            _dataContext.SaveChanges();
            return branchCars;
        }

    }
}
