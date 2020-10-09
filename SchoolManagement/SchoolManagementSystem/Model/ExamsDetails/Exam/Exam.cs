using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class Exam
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string ExamType { get; set; }
        [Required]
        [StringLength(200)]
        public string ExamDiscription { get; set; }        
        [Required]
        [DataType(DataType.Date), Column(TypeName = "date")]
        public DateTime StartDate { get; set; }          
        [Required]
        [DataType(DataType.Date), Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        [Required]
        public int PassingRate { get; set; }

        [Required]
        public bool IsActive { get; set; }
        [Required]
        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual ICollection<ExamMark> ExamMark { get; set; }
        public virtual ICollection<ExamResult> ExamResult { get; set; }
        public virtual ICollection<ExamRoutine> ExamRoutine { get; set; }
    }
}
