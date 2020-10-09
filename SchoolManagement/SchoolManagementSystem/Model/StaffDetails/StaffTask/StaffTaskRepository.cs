using SchoolManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class StaffTaskRepository : IStaffTaskRepository
    {
        private readonly ApplicationDbContext _context;
        public StaffTaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Delete Staff Task
        public int DeleteStaffTask(int id)
        {
            StaffTask st = _context.StaffTask.Find(id);
            if (st != null)
            {
                _context.StaffTask.Remove(st);
            }
            try
            {
                var res = _context.SaveChanges();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Following
        //Get All Staff Task
        public IEnumerable<StaffTask> GetAllStaffTask() // int branchId
        {
            return _context.StaffTask.ToList();

        }

        //Get Staff By Id
        public StaffTask GetStaffTask(int id)
        {
            if (StaffTaskExists(id))
            {
                return this.GetAllStaffTask().Where(st => st.Id == id).FirstOrDefault();

            }
            return null;
        }

        //Save Staff Task
        public async Task<int> SaveStaffTask(StaffTask staffTask)
        {
            if (staffTask.Id == 0)
            {
                _context.StaffTask.Add(staffTask);
            }
            else
            {
                StaffTask st = _context.StaffTask.Find(staffTask.Id);

                if (st != null)
                {
                    st.TaskName = staffTask.TaskName;
                    st.Description = staffTask.Description;
                    _context.StaffTask.Update(st);

                }
            }
            try
            {
                var result = await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool StaffTaskExists(int id)
        {
            return _context.TaskRoutine.Any(s => s.Id == id);
        }

        //GetAllStaffWiseTask
        //public IEnumerable<StaffTask> GetAllStaffWiseTask(/*int StaffId, DateTime date*/int StaffId, int year);
        //{

        //    var StTask = _context.StaffTask.Where(w => w.StaffId == StaffId && w.StartDate.Year == year || w.EndDate.Year == year);


        //    return StTask.ToList();
        //}

    }
}
