using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public interface IExamResultRepository
    {
        Task<ExamResult> GetExamResultOfStudent(int examId, int studentId);
        Task<IEnumerable<ExamResult>> GetAllExamResultOfSection(int examId, int sectionId);
        Task<IEnumerable<ExamResult>> GetAllExamResultOfClass(int examId, int schoolClassId);

        Task<ExamResult> DeleteExamResult(int id);

        bool ExamResultExists(int id);

        public string GenerateExamResult(ResultGenerate resultGenerate);
    }
}
