using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class Shift
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string ShiftName { get; set; }
        [Required]
        public TimeSpan StartTime { get; set; }
        [Required]
        public TimeSpan EndTime { get; set; }
        public virtual ICollection<BranchClass> BranchClass { get; set; }
    }
}
