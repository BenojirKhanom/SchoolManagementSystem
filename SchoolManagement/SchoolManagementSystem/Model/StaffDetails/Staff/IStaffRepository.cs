using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public interface IStaffRepository
    {
       
      public  Task< IEnumerable<Staff>> GetAllStaffByBranch(int branchId);

      public  Task<Staff> GetStaff(int id);

        Task<Staff> AddStaff(Staff staff);
        public Task<Staff> UpdateStaff(int id, Staff staff);
        Task<Staff> DeleteStaff(int id);



        IEnumerable<Staff> GetAllStaffByDesignation(int BranchId, int DesignatonId);
     
        public Task<Staff> EditStaffProfile(int id, Staff staff);

        IEnumerable<Staff> GetAllStaffCheckResign(int branchId);

        IEnumerable<Staff> GetBranchWiseActiveStaff(int branchId);
    }
}
