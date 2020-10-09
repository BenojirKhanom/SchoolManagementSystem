using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public interface IStaffTaskRepository
    {
        IEnumerable<StaffTask> GetAllStaffTask();
        StaffTask GetStaffTask(int id);

        Task<int> SaveStaffTask(StaffTask staffTask);

        int DeleteStaffTask(int id);

        bool StaffTaskExists(int id);

        //IEnumerable<StaffTask> GetAllStaffWiseTask(/*int StaffId, DateTime date*/int StaffId, int year);
        //IEnumerable<StaffTask> GetAllStaffWiseTask(/*int StaffId, DateTime date*/int StaffId, int year, int month);
        //IEnumerable<StaffTask> GetAllStaffWiseTask(/*int StaffId, DateTime date*/int StaffId, int year, int month, int date);
    }
}
