using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public interface IExamMarkRepository
    {
        IEnumerable<ExamMark> GetAllExamMarkOfSection(int examId, int sectionId);
        IEnumerable<ExamMark> GetAllExamMarkOfStudent(int examId, int studentId);
        ExamMark GetExamMarkOfStudent(int examId, int studentId, int subjectId);

        ExamMark DeleteExamMark(int id);
        bool ExamMarkExists(int id);

        public string AddExamMark(ExamMark examMark);
    }
}
