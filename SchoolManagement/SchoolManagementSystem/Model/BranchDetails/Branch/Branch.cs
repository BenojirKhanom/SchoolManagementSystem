using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class Branch
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string BranchName { get; set; }
        [Required]
        [StringLength(200)]
        public string Location { get; set; }
        [Required]
        [StringLength(200)]
        public string Authority { get; set; }
        [StringLength(8)]
        [DataType(DataType.Password)]
        [NotMapped]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [NotMapped]
        [Compare("Password", ErrorMessage = "Password Not match!")]
        public string ConfirmPassword { get; set; }
        [Required]
        [ForeignKey("PostOffice")]
        public int PostOfficeId { get; set; }
        public virtual PostOffice PostOffice { get; set; }
        public virtual ICollection<Exam> Exam { get; set; }
        public virtual ICollection<NoticeBoard> NoticeBoard { get; set; }
        public virtual ICollection<Room> Room { get; set; }
        public virtual ICollection<RulesRegulation> RulesRegulation { get; set; }
        public virtual ICollection<Staff> Staff { get; set; }
        public virtual ICollection<Teacher> Teacher { get; set; }
        public virtual ICollection<BranchClass> BranchClass { get; set; }
        public virtual ICollection<Event> Event { get; set; }

        public virtual ICollection<ExamResultPoint> ExamResultPoint { get; set; }
    }
}
