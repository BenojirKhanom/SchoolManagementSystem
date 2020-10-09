using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public interface ITeacherRepository
    {  

        public Task<IEnumerable<Teacher>> GetAllTeacherByBranch(int branchId);
        public Task<Teacher> GetTeacherByID(int id);
        public Task<Teacher> UpdateTeacher(int id, Teacher teacher);
        public Task<Teacher> AddTeacher(Teacher teacher);
        public Task<Teacher> DeleteTeacher(int id);

        IEnumerable<Teacher> GetSubjectWiseTeacherForBranch(int branchId, int subjectId);

        IEnumerable<Teacher> GetAllTeacherCheckResign(int branchId);

        IEnumerable<Teacher> GetBranchWiseActiveTeacher(int branchId);

        /////////////Subject Teachar///////////////////////
        public Task<SubjectTeacher> AddSubjectTeacher(SubjectTeacher teacher);
        public Task<SubjectTeacher> DeleteSubjectTeacher(int id);
    }
}
