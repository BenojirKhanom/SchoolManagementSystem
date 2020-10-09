using SchoolManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ApplicationDbContext _context;
        public SubjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Subject> GetAllSubject()
        {
            return _context.Subject.ToList();
        }

        public Subject GetSubject(int id)
        {

            if (SubjectExists(id))
            {
                return this.GetAllSubject().Where(edu => edu.Id == id).FirstOrDefault();
            }
            return null;
        }

        public Task<int> SaveSubject(Subject subject)
        {
            if (subject.Id == 0)
            {
                _context.Subject.Add(subject);
            }
            else
            {
                Subject edu = _context.Subject.Find(subject.Id);

                if (edu != null)
                {
                    //Update that subject
                    edu.SubjectName = subject.SubjectName;
                    edu.SubjectCode = subject.SubjectCode;
                    edu.SchoolClassId = subject.SchoolClassId;
                    _context.Subject.Update(edu);
                }
            }
            try
            {
                var result = _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int DeleteSubject(int id)
        {
            Subject edu = _context.Subject.Find(id);
            if (edu != null)
            {
                _context.Subject.Remove(edu);
            }
            try
            {
                var res = _context.SaveChanges();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool SubjectExists(int id)
        {
            return _context.BranchClass.Any(e => e.Id == id);
        }

        //Mohammad Alauddin
        public IEnumerable<BranchClass> GetBranchWiseClass(int StudentId)
        {
            List<BranchClass> bclassList = new List<BranchClass>();
            var student = _context.Student.Where(a => a.Id == StudentId);
            foreach (var st in student)
            {
                //var BranchClass = _context.BranchClass.Where(e => e.Id == st.BranchClassId).FirstOrDefault();
                //bclassList.Add(BranchClass);
            }
            return bclassList.ToList();

        }

        //Mohammad Alauddin
        public IEnumerable<Subject> GetAllSubjectForStudent(int StudentId)
        {
            List<Subject> subjectList = new List<Subject>();
            var BranchClasses = this.GetBranchWiseClass(StudentId);
            foreach (var a in BranchClasses)
            {
                var subject = _context.Subject.Where(sb => sb.SchoolClassId == a.Id);
                foreach (Subject sb in subject)
                {
                    subjectList.Add(sb);
                }
            }

            return subjectList;

        }

        // Imran (15)
        public IEnumerable<Subject> GetClassWiseSubject(int classId)
        {
            var sub = _context.Subject.Where(s => s.SchoolClassId == classId);
            return sub;
        }




        //********BranchWise Subject ********* Zulhas
        public IEnumerable<Subject> GetAllSubjectForBranch(int BranchId)
        {
            List<Subject> subjectList = new List<Subject>();
            var classList = this.GetBranchWiseClass(BranchId);
            foreach (var a in classList)
            {
                var subject = _context.Subject.Where(sb => sb.SchoolClassId == a.Id);
                foreach (Subject sb in subject)
                {
                    subjectList.Add(sb);
                }
            }
            return subjectList;
        }


    }
}
