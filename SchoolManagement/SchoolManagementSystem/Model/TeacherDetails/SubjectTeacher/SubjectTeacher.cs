using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class SubjectTeacher
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        [Required]
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
