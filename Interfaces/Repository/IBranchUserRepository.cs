using VehiChoice.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiChoice.Repository.Interface
{
    public interface IBranchUserRepository
    {
        BranchUsers Create(BranchUsers branchUsers);
    }
}
