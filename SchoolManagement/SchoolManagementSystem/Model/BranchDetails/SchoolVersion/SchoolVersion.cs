using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class SchoolVersion
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string SchoolVersionName { get; set; }
        public virtual ICollection<BranchClass> BranchClass { get; set; }
        public virtual ICollection<Subject> Subject { get; set; }
    }
}
