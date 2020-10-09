using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class Designation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string DesignationName { get; set; }
        public virtual ICollection<Staff> Staff { get; set; }
        public virtual ICollection<Teacher> Teacher { get; set; }
    }
}
