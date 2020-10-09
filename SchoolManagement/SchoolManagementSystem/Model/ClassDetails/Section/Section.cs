using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class Section
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string SectionName { get; set; }
        public int? GroupId { get; set; }
        public virtual Group Group { get; set; }
        [Required]
        [ForeignKey("BranchClass")]
        public int BranchClassId { get; set; }
        [ForeignKey("Room")]
        public int? RoomId { get; set; } //this is class room
        [ForeignKey("Teacher")]
        public int? TeacherId { get; set; } //this is class teacher

        public virtual Room Room { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual BranchClass BranchClass { get; set; }
        public virtual ICollection<ClassRoutine> ClassRoutine { get; set; }
        public virtual ICollection<Student> Student { get; set; }
        public virtual ICollection<ExamResult> ExamResult { get; set; }
    }
}
