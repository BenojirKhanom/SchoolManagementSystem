using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class StaffTask
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string TaskName { get; set; }

        [Required]
        [StringLength(700)]
        public string Description { get; set; }
    }
}
