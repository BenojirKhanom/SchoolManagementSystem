using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class SchoolClass
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string ClassName { get; set; }
        public int NumberOfSubject { get; set; }
        public virtual ICollection<BranchClass> BranchClass { get; set; }
        public virtual ICollection<Subject> Subject { get; set; }

    }  
}
