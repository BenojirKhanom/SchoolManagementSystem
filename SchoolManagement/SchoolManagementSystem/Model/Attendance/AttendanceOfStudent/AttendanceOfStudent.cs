using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class AttendanceOfStudent
    {
        public int Id { get; set; }
        [DataType(DataType.Date), Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [DataType(DataType.Time), Column(TypeName = "time")]
        public TimeSpan InTime { get; set; }

        [DataType(DataType.Time), Column(TypeName = "time")]
        public TimeSpan OutTime { get; set; }
        [ForeignKey("Student")] 
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
