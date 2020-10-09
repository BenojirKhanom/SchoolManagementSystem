using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class StudentSubject
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [Required]
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        [Required]
        public bool IsOptional { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }

    }
}
