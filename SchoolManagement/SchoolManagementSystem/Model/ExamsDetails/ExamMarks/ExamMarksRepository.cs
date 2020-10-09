using SchoolManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class ExamMarkRepository : IExamMarkRepository
    {
        private readonly ApplicationDbContext _context;
        public ExamMarkRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ExamMark> GetAllExamMarkOfSection(int examId, int sectionId)
        {
            List<ExamMark> examMarkList = new List<ExamMark>();
            List<Student> studentList = _context.Student.Where(e => e.SectionId == sectionId).ToList();
            if (studentList.Count() > 0)
            {
                foreach (Student student in studentList)
                {
                    List<ExamMark> examMarks = _context.ExamMark.Where(e => e.ExamId == examId && e.StudentId == student.Id).ToList();
                    if (examMarks.Count() > 0)
                    {
                        examMarkList.AddRange(examMarks);
                    }
                }
                return examMarkList;
            }

            return null;
        }

        public IEnumerable<ExamMark> GetAllExamMarkOfStudent(int examId, int studentId)
        {
            List<ExamMark> examMarks = _context.ExamMark.Where(e => e.ExamId == examId && e.StudentId == studentId).ToList();
            if (examMarks.Count() > 0)
            {
                return examMarks;
            }
            return null;
        }

        public ExamMark GetExamMarkOfStudent(int examId, int studentId, int subjectId)
        {
            var rotine = _context.ExamRoutine.Where(r => r.ExamId == examId && r.SubjectId == subjectId).FirstOrDefault();
            if (rotine == null)
            {
                return null;
            }
            ExamMark examMark = _context.ExamMark.Where(em => em.ExamId == examId
                                        && em.StudentId == studentId
                                        && em.ExamRoutineId == rotine.Id).FirstOrDefault();
            if (examMark == null)
            {
                return null;
            }
            return examMark;
        }

        public ExamMark DeleteExamMark(int id)
        {
            ExamMark edu = _context.ExamMark.Find(id);
            if (edu != null)
            {
                _context.ExamMark.Remove(edu);
                _context.SaveChanges();
                return edu;
            }
            return null;
        }


        public bool ExamMarkExists(int id)
        {
            return _context.ExamMark.Any(e => e.Id == id);
        }



        public bool IsPassed(float total, int passingRate, float marks)
        {
            if (marks >= total * passingRate / 100)// edit
            {
                return true;
            }
            return false;
        }
        public ExamResultPoint GradePoint(int branchId, float total, float marks)
        {
            var val = (int)(marks * 100 / total);
            var point = _context.ExamResultPoint.Where(p => p.BranchId == branchId
                                                   && p.MaximumMark >= val && p.MinimumMark <= val).FirstOrDefault();
            if (point == null)
            {
                return null;
            }
            return point;
        }
        public string AddExamMark(ExamMark examMark)
        {

            // check This mark is already exist
            var markExist = _context.ExamMark.Where(e => e.ExamId == examMark.ExamId
                                                && e.StudentId == examMark.StudentId
                                                && e.ExamRoutineId == examMark.ExamRoutineId).FirstOrDefault();



            //check this student is Present in exam and this subject is in rotine.    =>addorupdate
            var isStudentPresentInExam = false;
            var rotine = _context.ExamRoutine.Where(r => r.Id == examMark.ExamRoutineId
                            && r.ExamId == examMark.ExamId).FirstOrDefault();

            if (rotine != null)
            {
                var stAttend = _context.AttendanceOfStudent.Where(at => at.StudentId == examMark.StudentId
                                                 && at.Date.Date == rotine.ExamDate.Date).FirstOrDefault();
                if (stAttend != null)
                {
                    isStudentPresentInExam = true;
                }
                else
                {
                    return "Student not Attend this Exam.";
                }

            }

            //check this subject is in  student  class.
            var isStudentSubject = false;
            int branchId = 0;
            if (isStudentPresentInExam)
            {
                var student = _context.Student.Where(s => s.Id == examMark.StudentId).FirstOrDefault();
                if (student != null)
                {
                    var stSecton = _context.Section.Where(a => a.Id == student.SectionId).FirstOrDefault();
                    var stClass = _context.BranchClass.Where(b => b.Id == stSecton.BranchClassId).FirstOrDefault();
                    branchId = stClass.BranchId;

                    var studentSubject = _context.StudentSubject.Where(ss => ss.StudentId == student.Id
                                    && ss.SubjectId == rotine.SubjectId).FirstOrDefault();
                    
                    if (stClass != null && studentSubject != null)
                    {
                        var subject = _context.Subject.Where(sb => sb.Id == rotine.SubjectId
                                                            && sb.SchoolClassId == stClass.SchoolClassId).FirstOrDefault();
                        if (subject != null)
                        {
                            isStudentSubject = true;
                        }
                    }
                }

            }


            if (isStudentSubject && isStudentPresentInExam)
            {

                Exam exam = _context.Exam.Where(e => e.Id == examMark.ExamId).FirstOrDefault();
                ExamResultPoint examResultPoint = GradePoint(branchId, (float)rotine.TotalNumber, examMark.ObtainMark);

                examMark.ResultStatus = IsPassed((float)rotine.TotalNumber, exam.PassingRate, examMark.ObtainMark);

                examMark.Point = examResultPoint.Point;
                if (examMark.ResultStatus)
                {
                    examMark.Grade = examResultPoint.Grade;
                }
                else
                {
                    examMark.Grade = "F";
                }

                if (markExist == null)
                {
                    _context.ExamMark.Add(examMark);
                    _context.SaveChanges();

                    return setPositionAndHighest(examMark, "Inserted");

                    //return examMark;
                }
                else
                {
                    markExist.ObtainMark = examMark.ObtainMark;
                    markExist.ResultStatus = examMark.ResultStatus;
                    markExist.Point = examMark.Point;
                    markExist.Grade = examMark.Grade;

                    _context.ExamMark.Update(markExist);
                    _context.SaveChanges();

                    return setPositionAndHighest(markExist, "Updated");

                    //return markExist;
                }

            }
            return null;
        }
        public string setPositionAndHighest(ExamMark examMark, string status)
        {
            List<ExamMark> markList = new List<ExamMark>();

            Student student = _context.Student.Where(s => s.Id == examMark.StudentId).FirstOrDefault();
            if (student != null)
            {
                List<Student> studentList = _context.Student.Where(st => st.SectionId == student.SectionId).ToList();
                foreach (Student st in studentList)
                {
                    var mark = _context.ExamMark.Where(e => e.StudentId == st.Id
                                                   && e.ExamId == examMark.ExamId
                                                   && e.ExamRoutineId == examMark.ExamRoutineId).FirstOrDefault();
                    if (mark != null)
                    {
                        markList.Add(mark);
                    }
                }
            }



            if (markList.Count() > 0)
            {
                markList.Sort((a, b) => a.ObtainMark.CompareTo(b.ObtainMark));
                markList.Reverse();
                var highestscore = markList[0].ObtainMark;
                var position = 0;
                foreach (ExamMark em in markList)
                {
                    em.HighestMark = highestscore;
                    em.Position = position + 1;
                    position = (int)em.Position;
                }
                _context.ExamMark.UpdateRange(examMark);
                _context.SaveChanges();

                return @"Successfully " + status + " a mark which result status is " + examMark.ResultStatus +
                       ", Point " + examMark.Point + ", Grade " + examMark.Grade + ", Position " + examMark.Position +
                       ", Highest mark this section is " + examMark.HighestMark;
            }

            return @"Successfully " + status + " a mark but not set position & Highest mark";
        }


    }
}
