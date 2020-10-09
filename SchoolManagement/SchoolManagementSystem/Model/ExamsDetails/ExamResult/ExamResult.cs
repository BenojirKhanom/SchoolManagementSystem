using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{

    public class ExamResult
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date), Column(TypeName = "date")]
        public DateTime ResultPublishDate { get; set; }
        [Required]
        public int TotalMark { get; set; }
        [Required]
        public float TotalObtainMark { get; set; }
        [Required]
        public bool ResultStatus { get; set; }
        [Required]
        public double Point { get; set; }
        [Required]
        [StringLength(2)]
        public string Grade { get; set; }
        public float? HighestMark { get; set; }
        public int? Position { get; set; }
        public int? TotalPresent { get; set; }
        [StringLength(500)]
        public string Note { get; set; }
        [Required]
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        [Required]
        [ForeignKey("Section")]
        public int SectionId { get; set; }
        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Exam Exam { get; set; }
        public virtual Section Section { get; set; }
        public virtual Student Student { get; set; }

    }
    
}
