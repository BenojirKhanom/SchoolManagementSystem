using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class ExamRoutine
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date), Column(TypeName = "date")]
        public DateTime ExamDate { get; set; }
        [Required]
        [DataType(DataType.Time), Column(TypeName = "time")]
        public TimeSpan StartTime { get; set; }
        [Required]
        [DataType(DataType.Time), Column(TypeName = "time")]
        public TimeSpan EndTime { get; set; }
        [StringLength(100)]
        public string Duration { get; set; }
        [Required]
        public int TotalNumber { get; set; }
        [Required]
        [ForeignKey("BranchClass")]
        public int BranchClassId { get; set; }
        [Required]
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        [Required]
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public virtual BranchClass BranchClass { get; set; }
        public virtual Exam Exam { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<ExamMark> ExamMark { get; set; }

    }
}
