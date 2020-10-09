using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class District
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string DistrictName { get; set; }
        [Required]
        [ForeignKey("Division")]
        public int DivisionId { get; set; }        
        public virtual Division Division { get; set; }        
        public virtual ICollection<PoliceStation> PoliceStation { get; set; }

    }
}
