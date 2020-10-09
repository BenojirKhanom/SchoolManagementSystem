using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class Division
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string DivisionName { get; set; }
        [Required]
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }        
        public virtual ICollection<District> District { get; set; }

    }
}
