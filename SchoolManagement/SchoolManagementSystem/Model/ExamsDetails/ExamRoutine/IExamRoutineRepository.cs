using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public interface IExamRoutineRepository
    {
        Task<List<ExamRoutine>> GetAllExamRoutines();

        Task<ExamRoutine> GetExamRoutine(int id);

        Task<int> AddExamRoutine(ExamRoutine examRoutine);

        Task UpdateExamRoutine(ExamRoutine examRoutine);

        Task<int> DeleteExamRoutine(int? id);
    }
}
