using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class ExamResultPoint
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int MaximumMark { get; set; }
        [Required]
        public int MinimumMark { get; set; }
        [Required]
        public double Point { get; set; }
        [Required]
        [StringLength(2)]
        public string Grade { get; set; }
        [Required]
        [StringLength(500)]
        public string Note { get; set; }
        [Required]
        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
    }
}
