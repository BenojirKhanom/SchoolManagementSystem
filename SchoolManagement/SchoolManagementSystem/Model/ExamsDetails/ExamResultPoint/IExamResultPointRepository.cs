using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public interface IExamResultPointRepository
    {
        IEnumerable<ExamResultPoint> GetAllExamResultPointByBranch(int branchId);
        ExamResultPoint GetExamMark(int id);
        string SaveExamMark(ExamResultPoint ExamMark);
        ExamResultPoint DeleteExamMark(int id);
        bool ExamMarkExists(int id);
    }
}
