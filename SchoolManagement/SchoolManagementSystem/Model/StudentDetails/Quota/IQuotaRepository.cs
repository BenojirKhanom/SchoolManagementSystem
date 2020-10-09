using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{

    public interface IQuotaRepository
    {
        public Task<IEnumerable<Quota>> GetAllQuota(); //1
        public Task<Quota> GetQuota(int id); //2
        public Task<int> SaveQuota(Quota quota); //3
        public Task<Quota> DeleteQuota(int id); //4
        public Task<IEnumerable<Student>> QuotaWiseStudentList(int quotaId); //5 Current Year
        public Task<IEnumerable<Student>> QuotaWiseBranchStudentList(int branchId, int quotaId); //6 Current Year
        public Task<IEnumerable<Student>> QuotaWiseBranchClassStudentList(int branchId, int classId, int quotaId); //7 Current Year
    }

}
