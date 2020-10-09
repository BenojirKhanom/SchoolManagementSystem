using SchoolManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class AttendanceOfStudentRepository : IAttendanceOfStudentRepository
    {
        ApplicationDbContext _context;
        public AttendanceOfStudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int SaveAttendance(int studentId)
        {
            TimeSpan time = DateTime.UtcNow.AddHours(6).TimeOfDay;
            AttendanceOfStudent attendanceOfStudent = _context.AttendanceOfStudent.Where(ta => ta.StudentId == studentId && ta.Date == DateTime.UtcNow.AddHours(6).Date).FirstOrDefault();

            if (attendanceOfStudent == null)
            {
                AttendanceOfStudent NewAttendanceOfStudent = new AttendanceOfStudent { StudentId = studentId, Date = DateTime.UtcNow.AddHours(6).Date, InTime = time, OutTime = time };
                _context.AttendanceOfStudent.Add(NewAttendanceOfStudent);
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }

        public IEnumerable<object> GetStudentByNumber(/*string studentNumber*/)
        {
            var students = _context.Student.Select(a => new { a.Id, a.StudentIdNo }).ToList();
            if (students != null)
            {               
                return students;
            }
            return null;
        }
        public int GetStudentStatus(int id)
        {
            int outId = 0;
            string countEnrollment = _context.Student.Where(ta => ta.Id == id).Select(a => a.FingerData).FirstOrDefault();
            if (countEnrollment == null)
            {
                outId = -1;
            }
            else
            {
                int countAttendance = _context.AttendanceOfStudent.Where(ta => ta.StudentId == id  && ta.Date == DateTime.UtcNow.AddHours(6).Date).Count();
                if (countAttendance > 0)
                {
                    outId = _context.AttendanceOfStudent.Single(ta => ta.StudentId == id && ta.Date == DateTime.UtcNow.AddHours(6).Date).Id;
                }
            }
            return outId;
        }

        public void UpdateForOutTime(int id)
        {
            AttendanceOfStudent attendanceOfStudent = _context.AttendanceOfStudent.Find(id);

            attendanceOfStudent.OutTime = DateTime.UtcNow.AddHours(6).TimeOfDay;
            _context.AttendanceOfStudent.Update(attendanceOfStudent);
            _context.SaveChanges();
        }


        public string GetStudentFingerData(int id)
        {
            if (StudentExists(id))
            {
                var finger = _context.Student.Where(s => s.Id == id).Select(a => a.FingerData).FirstOrDefault();
                return finger;
            }
            return null;
        }
        public int registerStudentFinger(int id, string fingerdt)
        {
            if (StudentExists(id))
            {
                var student = _context.Student.Where(s => s.Id == id).FirstOrDefault();
                student.FingerData = fingerdt;
                _context.Student.Update(student);
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }
        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }
    }
}
