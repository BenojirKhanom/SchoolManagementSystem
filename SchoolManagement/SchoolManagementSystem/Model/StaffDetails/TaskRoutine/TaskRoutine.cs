using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class TaskRoutine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date), Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date), Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        [Required]
        [DataType(DataType.Time), Column(TypeName = "time")]
        public TimeSpan StartTime { get; set; }

        [Required]
        [DataType(DataType.Time), Column(TypeName = "time")]
        public TimeSpan EndTime { get; set; }

        [Required]
        [ForeignKey("StaffTask")]
        public int StaffTaskId { get; set; }

        [Required]
        [ForeignKey("Staff")]
        public int StaffId { get; set; }

        public virtual StaffTask StaffTask { get; set; }
        public virtual Staff Staff { get; set; }

    }
}
