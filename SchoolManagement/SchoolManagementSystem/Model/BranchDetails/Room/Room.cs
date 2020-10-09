using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public class Room
    {
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string RoomName { get; set; }
        [Required]
        [StringLength(100)]
        public string RoomType { get; set; }
        [Required]
        public int SitCapacity { get; set; }
        [Required]
        public int FloorNumber { get; set; }
        [Required]
        [StringLength(10)]
        public string BlockName { get; set; }
        [Required]
        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual ICollection<ClassRoutine> ClassRoutine { get; set; }
        public virtual ICollection<Section> Section { get; set; }
    }
}
