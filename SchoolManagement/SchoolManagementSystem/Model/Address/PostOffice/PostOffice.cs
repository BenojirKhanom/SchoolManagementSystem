using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class PostOffice
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string PostOfficeName { get; set; }
        [Required]
        [ForeignKey("PoliceStation")]
        public int PoliceStationId { get; set; }
        public virtual PoliceStation PoliceStation { get; set; }
        public virtual ICollection<ApplicationForm> ApplicationForm { get; set; }
        public virtual ICollection<Staff> Staff { get; set; }
        public virtual ICollection<Student> Student { get; set; }
        public virtual ICollection<Teacher> Teacher { get; set; }
    }
}
