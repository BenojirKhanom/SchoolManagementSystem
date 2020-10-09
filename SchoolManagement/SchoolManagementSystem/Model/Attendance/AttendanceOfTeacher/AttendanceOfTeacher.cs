using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class AttendanceOfTeacher
    {
        public int Id { get; set; }
        [DataType(DataType.Date), Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [DataType(DataType.Time), Column(TypeName = "time")]
        public TimeSpan InTime { get; set; }

        [DataType(DataType.Time), Column(TypeName = "time")]
        public TimeSpan OutTime { get; set; }
        [ForeignKey("Teacher")]
        public int  TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
