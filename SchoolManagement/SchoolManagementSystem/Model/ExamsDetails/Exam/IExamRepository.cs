using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public interface IExamRepository
    {
        IEnumerable<Exam> GetAllExam(int branchId, int year);
        Exam getExam(int id);
        public Task<Exam> DeleteExam(int id);
        public Task<Exam> AddNewExam(Exam exam);
    }
}
