using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public interface IAttendanceOfStudentRepository
    {
        public IEnumerable<object> GetStudentByNumber(/*string studentNumber*/);
        public string GetStudentFingerData(int id);
        public int registerStudentFinger(int id, string fingerdt);
        public int SaveAttendance(int studentId);
        public int GetStudentStatus(int id);
        public void UpdateForOutTime(int id);
    }
}
