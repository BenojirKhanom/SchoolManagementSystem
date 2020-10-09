using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class Quota
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string QuotaName { get; set; }

        public virtual ICollection<ApplicationForm> ApplicationForm { get; set; }
        public virtual ICollection<Student> Student { get; set; }
    }
}
