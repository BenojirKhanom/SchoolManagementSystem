using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public interface IApplicationFormRepository
    {
        public IEnumerable<ApplicationForm> GetAllApplicant();
        public Task<ApplicationForm> SaveApplication(ApplicationForm applicationForm); // 1
        public Task<ApplicationForm> GetApplicantInfo(string applicantId);  // 2
        public Task<ApplicationForm> GetApplicant(int id);  // 3
        public IEnumerable<ApplicationForm> GetCurrentYearApplicantList();  // 4      
        public IEnumerable<ApplicationForm> GetCurrentYearApplicantListBranchWise(int branchId);    // 5
        public IEnumerable<ApplicationForm> GetCurrentYearApplicantListBranchClassWise(int branchId, int classId);  // 6

        public Task<int> DeleteApplication(int id); // 7
    }
}
