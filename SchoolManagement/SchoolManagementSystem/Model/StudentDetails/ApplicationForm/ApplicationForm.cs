using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class ApplicationForm
    {
        [Key]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string ApplicantId { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Date), Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int Gender { get; set; }

        [Required]
        public int Religion { get; set; }

        [Required, StringLength(20)]
        public string BirthRegistrationNo { get; set; }

        [Required, StringLength(1000)]
        public string ImageUrl { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataType(DataType.Date), Column(TypeName = "date")]
        public DateTime ApplingDate { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(50)]
        public string FatherName { get; set; }
        [Required]
        [StringLength(50)]
        public string FatherOccupation { get; set; }
        [Required]
        [StringLength(15)]
        public string FatherPhone { get; set; }
        [Required]
        [StringLength(50)]
        public string MotherName { get; set; }
        [Required]
        [StringLength(50)]
        public string MotherOccupation { get; set; }
        [Required]
        [StringLength(15)]
        public string MotherPhone { get; set; }
        [Required]
        public int MonthlyFamillyIncome { get; set; }
        [StringLength(200)]
        public string FormarSchoolName { get; set; }

        [DefaultValue(false)]
        public bool IsSelected { get; set; } = false;       // Selected for Admission

        [DefaultValue(false)]
        public bool IsAdmitted { get; set; } = false;

        [Required]
        [StringLength(500)]
        public string PresentAddress { get; set; }
        [Required]
        [StringLength(500)]
        public string ParmanentAddress { get; set; }
        [Required, ForeignKey("PostOffice")]
        public int PostOfficeId { get; set; }
        public virtual PostOffice PostOffice { get; set; }
        [ForeignKey("Quota")]
        public int? QuotaId { get; set; }
        public virtual Quota Quota { get; set; }
        [Required]
        [ForeignKey("BranchClass")]
        public int BranchClassId { get; set; }
        public virtual BranchClass BranchClass { get; set; }

        //public string trxID { get; set; }


    }
}
