using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public interface IStudentRepository
    {
        public Task<IEnumerable<Student>> GetAllStudents();
        public Task<Student> GetStudent(int id); // 1
        public Task<Student> GetStudentInfo(string studentId); // 2
        public Task<Student> SaveStudent(string applicantId); // 3
        public Task<int> UpdateStudent(Student student);    // 4
        public Task<Student> DeleteStudent(int id);    // 5

        public IEnumerable<Student> GetClassWiseStudentList(int branchId, int classId); // 6
    }
}
