using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class Student
    {
        [Key]

        public int Id { get; set; }
        [Required]
        public string StudentIdNo { get; set; }   //Student Id Number Application From  
        public int? RollNo { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string FullName { get; set; }
        [Required]
        [DataType(DataType.Date), Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [StringLength(20)]
        public string BirthRegistrationNo { get; set; }
        [Required]
        public int Gender { get; set; }
        [Required]
        public int Religion { get; set; }
        public int? BloodGroup { get; set; }

        [Required, StringLength(1000)]
        public string ImageUrl { get; set; }
        [Required]
        [StringLength(500)]
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
        [DataType(DataType.Password)]
        [NotMapped]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [NotMapped]
        [Compare("Password", ErrorMessage = "Password Not match!")]
        public string ConfirmPassword { get; set; }

        [StringLength(50)]
        public string GuardianName { get; set; }

        [StringLength(15)]
        public string GuardianPhoneNo { get; set; }

        [EmailAddress]
        public string GuardianEmail { get; set; }

        [StringLength(100)]
        public string RelationOfAltGuardian { get; set; }
        [DataType(DataType.Date), Column(TypeName = "date")]
        public DateTime AdmissionDate { get; set; }
        [Required]
        public string PresentAddress { get; set; }
        [Required]
        [StringLength(500)]
        public string ParmanentAddress { get; set; }
        public string FingerData { get; set; }
        [Required, ForeignKey("PostOffice")]
        public int PostOfficeId { get; set; }
        public virtual PostOffice PostOffice { get; set; }
        [ForeignKey("Quota")]
        public int? QuotaId { get; set; }
        public virtual Quota Quota { get; set; }
        [ForeignKey("Section")]
        public int? SectionId { get; set; }
        public virtual Section Section { get; set; }
        public virtual ICollection<ExamResult> ExamResult { get; set; }
        public virtual ICollection<ExamMark> ExamMark { get; set; }
        public virtual ICollection<AttendanceOfStudent> AttendanceOfStudent { get; set; }
        public virtual ICollection<StudentSubject> StudentSubject { get; set; }
    }
}
