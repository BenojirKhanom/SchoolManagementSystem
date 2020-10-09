using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class AttendanceOfStaff
    {
        public int Id { get; set; }
        [DataType(DataType.Date), Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [DataType(DataType.Time), Column(TypeName = "time")]
        public TimeSpan InTime { get; set; }

        [DataType(DataType.Time), Column(TypeName = "time")]
        public TimeSpan OutTime { get; set; }
        [ForeignKey("Staff")]
        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
