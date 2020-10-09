using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class Group
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string GroupName { get; set; }
        public virtual ICollection<Section> Section { get; set; }
        public virtual ICollection<Subject> Subject { get; set; }
    }
}
