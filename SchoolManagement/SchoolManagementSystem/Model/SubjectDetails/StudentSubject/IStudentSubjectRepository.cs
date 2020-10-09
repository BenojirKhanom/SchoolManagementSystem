using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public interface IStudentSubjectRepository
    {
        public Task<IEnumerable<StudentSubject>> GetAllStudentSubjects();

        public Task<StudentSubject> GetStudentSubject(int id);
        public Task<StudentSubject> AddStudentSubject(StudentSubject model);
        public Task<StudentSubject> DeleteStudentSubjectt(int id);

        
    }
}
