using VehiChoice.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiChoice.Interfaces.Repository
{
    public interface IBranchCarServices
    {
        BranchCars Create(BranchCars branchCars);
    }
}
