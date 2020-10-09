using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class Subject
    {  [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string SubjectName { get; set; }
        [Required]
        [StringLength(6)]
        public string SubjectCode { get; set; }
        public bool CanBeOptional { get; set; }
        [StringLength(1000)]
        public string DownloadLink { get; set; }
        [Required]
        [ForeignKey("SchoolClass")]
        public int SchoolClassId { get; set; }
        public virtual SchoolClass SchoolClass { get; set; }
        [ForeignKey("Group")]
        public int? GroupId { get; set; }
        public virtual Group Group { get; set; }
        [ForeignKey("SchoolVersion")]
        public int? SchoolVersionId { get; set; }
        public virtual SchoolVersion SchoolVersion { get; set; }
        public virtual ICollection<ClassRoutine> ClassRoutine { get; set; }
        public virtual ICollection<ExamRoutine> ExamRoutine { get; set; }
        public virtual ICollection<SubjectTeacher> SubjectTeacher { get; set; }
        public virtual ICollection<StudentSubject> StudentSubject { get; set; }
    }
}
