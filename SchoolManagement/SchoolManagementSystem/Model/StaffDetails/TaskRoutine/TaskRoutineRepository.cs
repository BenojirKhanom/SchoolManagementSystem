using SchoolManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class TaskRoutineRepository : ITaskRoutineRepository
    {
        private readonly ApplicationDbContext _context;
        public TaskRoutineRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //public string SaveNewTaskRoutine(TaskRoutine taskRoutine)
        //{
        //    var TaskRoutineExist = _context.TaskRoutine.Where(tr => tr.)
        //}



        // Delete Task Routine
        public int DeleteTaskRoutine(int id)
        {
            TaskRoutine tr = _context.TaskRoutine.Find(id);

            if(tr != null)
            {
                _context.TaskRoutine.Remove(tr);
            }
            try
            {
                var res = _context.SaveChanges();
                return res;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //Get All Task Routin
        public IEnumerable<TaskRoutine> GetAllTaskRoutine()
        {
            return _context.TaskRoutine.ToList();
        }

        //Get Task By Id 
        public TaskRoutine GetTaskRoutine(int id)
        {
            if (TaskRoutineExists(id))
            {
                return this.GetAllTaskRoutine().Where(tr => tr.Id == id).FirstOrDefault();
            }
            return null;
        }

        //Save Task Routine
        public Task<int> SaveTaskRoutine(TaskRoutine taskRoutine)
        {
            if(taskRoutine.Id == 0)
            {
                _context.TaskRoutine.Add(taskRoutine);
            }
            else
            {
                TaskRoutine tr = _context.TaskRoutine.Find(taskRoutine.Id);

                if(tr != null)
                {
                    tr.StartDate = taskRoutine.StartDate;
                    tr.EndDate = taskRoutine.EndDate;

                    tr.StartTime = taskRoutine.StartTime;
                    tr.EndTime = taskRoutine.EndTime;

                    //tr.StaffId = taskRoutine.StaffId;
                    //tr.TaskId = taskRoutine.TaskId;
                    _context.TaskRoutine.Update(tr);

                }
            }
            try
            {
                var result = _context.SaveChangesAsync();
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool TaskRoutineExists(int id)
        {
            return _context.TaskRoutine.Any(e => e.Id == id);
        }
    }
}
