using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class ExamMark
    {

        public int Id { get; set; }
        [Required]
        public float ObtainMark { get; set; }
        public bool ResultStatus { get; set; }
        public double Point { get; set; }
        [StringLength(2)]
        public string Grade { get; set; }
        public float? HighestMark { get; set; }
        public int? Position { get; set; }
        [Required]
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        [Required]
        [ForeignKey("ExamRoutine")]
        public int ExamRoutineId { get; set; }
        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Exam Exam { get; set; }
        public virtual Student Student { get; set; }
        public virtual ExamRoutine ExamRoutine { get; set; }

    }
}
