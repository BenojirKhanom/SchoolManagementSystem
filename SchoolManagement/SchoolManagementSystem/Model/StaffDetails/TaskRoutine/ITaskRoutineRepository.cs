using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public interface ITaskRoutineRepository
    {
        IEnumerable<TaskRoutine> GetAllTaskRoutine();

        TaskRoutine GetTaskRoutine(int id);

        Task<int> SaveTaskRoutine(TaskRoutine taskRoutine);

        int DeleteTaskRoutine(int id);


        bool TaskRoutineExists(int id);

        


    }
}
