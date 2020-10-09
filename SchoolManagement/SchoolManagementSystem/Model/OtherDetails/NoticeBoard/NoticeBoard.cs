using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class NoticeBoard
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string TopicName { get; set; }
        [Required]
        public string NoticeBody { get; set; }
        [Required]
        [DataType(DataType.Date), Column(TypeName = "date")]
        public DateTime PublishDate { get; set; }
        [Required]
        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }

    }
}
