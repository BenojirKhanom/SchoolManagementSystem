using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public interface IBranchRepository
    {
        public Task<IEnumerable<Branch>> GetAllBranchs();
        public Task<Branch> GetBranch(int id);
        Task<Branch> SaveBranch(Branch Branch);
        Task<Branch> DeleteBranch(int? id);

        public IEnumerable<SchoolClass> GetBranchWiseClass(int BranchId);
        public IEnumerable<Subject> GetAllSubjectForBranch(int BranchId);
    }
}
