using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> GetAllSubject();

        Subject GetSubject(int id);

        Task<int> SaveSubject(Subject subject);

        int DeleteSubject(int id);


        bool SubjectExists(int id);

        IEnumerable<Subject> GetAllSubjectForStudent(int StudentId);
        IEnumerable<Subject> GetClassWiseSubject(int classId);
        public IEnumerable<Subject> GetAllSubjectForBranch(int BranchId);

    }
}
