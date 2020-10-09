using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string EventName { get; set; }
        [Required]
        [DataType(DataType.Date), Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date), Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        [Required]
        [StringLength(100)]
        public string EventControlar { get; set; }
        [Required]
        public string Venue { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
    }
}
