using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public interface IBranchClassRepository
    {
        public Task<IEnumerable<BranchClass>> GetBranchClassByBranch(int branchId, int shiftId);
        public Task<BranchClass> GetBranchClass(int id);
        //public Task<BranchClass> UpdateBranchClass(int id, BranchClass classRoom);
        public Task<BranchClass> CreateBranchClass(BranchClass branchClass);
        public Task<BranchClass> DeleteBranchClass(int id);
    }
}
