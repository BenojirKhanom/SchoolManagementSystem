using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class ClassRoutine
    {
        public int Id { get; set; }
        [Required]
        [StringLength(15)]
        public string DayOfWeek { get; set; }
        [Required]
        [DataType(DataType.Time), Column(TypeName = "time")]
        public TimeSpan StartTime { get; set; }
        [Required]
        [DataType(DataType.Time), Column(TypeName = "time")]
        public TimeSpan EndTime { get; set; }
        [Required]
        [StringLength(100)]
        public string ClassDuration { get; set; }
        [Required]
        public int PeriodNumber { get; set; }
        [Required]
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        [Required]
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        [ForeignKey("Room")]
        public int? RoomId { get; set; } //null thakbe insert after generate for optonal subject
        [Required]
        [ForeignKey("Section")]
        public int SectionId { get; set; }
        public virtual Section Section { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Room Room { get; set; }

    }
}
