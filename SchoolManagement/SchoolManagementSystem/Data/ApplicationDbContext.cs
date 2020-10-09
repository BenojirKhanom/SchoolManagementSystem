using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SchoolManagementSystem.Identity;

namespace SchoolManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Dedails About Under Method-https://entityframework.net/knowledge-base/39798317/identityuserlogin-string---requires-a-primary-key-to-be-defined-error-while-adding-migration
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });


            // https://eamonkeane.dev/computed-columns-in-entity-framework-core/
            // Create ApplicantId auto generate with Is Persisted YES
            builder.Entity<ApplicationForm>()
                .Property(a => a.ApplicantId)
                .HasComputedColumnSql("N'1'+ RIGHT('0000000'+CAST(Id AS VARCHAR(7)),7)PERSISTED");


            // Create Full Name with Is Persisted YES
            builder.Entity<ApplicationForm>()
                .Property(a => a.FullName)
                .HasComputedColumnSql("[FirstName] + ' ' + [LastName]PERSISTED");

            // Create Full Name with Is Persisted YES
            builder.Entity<Student>()
                .Property(s => s.FullName)
                .HasComputedColumnSql("[FirstName] + ' ' + [LastName]PERSISTED");


            //Note-https://www.learnentityframeworkcore.com/configuration/fluent-api/ondelete-method

            builder.Entity<Staff>()
               .HasOne(b => b.PostOffice)
               .WithMany(a => a.Staff)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationForm>()
               .HasOne(b => b.PostOffice)
               .WithMany(a => a.ApplicationForm)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Student>()
               .HasOne(b => b.PostOffice)
               .WithMany(a => a.Student)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ExamRoutine>()
               .HasOne(b => b.Subject)
               .WithMany(a => a.ExamRoutine)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ExamRoutine>()
               .HasOne(b => b.Exam)
               .WithMany(a => a.ExamRoutine)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ClassRoutine>()
               .HasOne(b => b.Subject)
               .WithMany(a => a.ClassRoutine)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ClassRoutine>()
               .HasOne(b => b.Teacher)
               .WithMany(a => a.ClassRoutine)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ExamMark>()
              .HasOne(b => b.Student)
              .WithMany(a => a.ExamMark)
              .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ExamMark>()
              .HasOne(b => b.ExamRoutine)
              .WithMany(a => a.ExamMark)
              .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ExamResult>()
              .HasOne(b => b.Student)
              .WithMany(a => a.ExamResult)
              .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ExamResult>()
              .HasOne(b => b.Section)
              .WithMany(a => a.ExamResult)
              .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<StudentSubject>()
              .HasOne(b => b.Subject)
              .WithMany(a => a.StudentSubject)
              .OnDelete(DeleteBehavior.Restrict);

        }

        public virtual DbSet<ApplicationForm> ApplicationForm { get; set; }
        public virtual DbSet<Branch> Branch { get; set; }
        public virtual DbSet<SchoolClass> SchoolClass { get; set; }
        public virtual DbSet<BranchClass> BranchClass { get; set; }
        public virtual DbSet<ClassRoutine> ClassRoutine { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Designation> Designation { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<Exam> Exam { get; set; }
        public virtual DbSet<ExamResult> ExamResult { get; set; }
        public virtual DbSet<ExamRoutine> ExamRoutine { get; set; }
        public virtual DbSet<ExamMark> ExamMark { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Holiday> Holiday { get; set; }
        public virtual DbSet<NoticeBoard> NoticeBoard { get; set; }
        public virtual DbSet<PoliceStation> PoliceStation { get; set; }
        public virtual DbSet<PostOffice> PostOffice { get; set; }
        public virtual DbSet<Quota> Quota { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<RulesRegulation> RulesRegulation { get; set; }
        public virtual DbSet<SchoolVersion> SchoolVersion { get; set; }
        public virtual DbSet<Section> Section { get; set; }
        public virtual DbSet<Shift> Shift { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }


        public virtual DbSet<ExamResultPoint> ExamResultPoint { get; set; }
        public virtual DbSet<StaffTask> StaffTask { get; set; }
        public virtual DbSet<TaskRoutine> TaskRoutine { get; set; }
        public virtual DbSet<StudentSubject> StudentSubject { get; set; }
        public virtual DbSet<SubjectTeacher> SubjectTeacher { get; set; }
        public virtual DbSet<RoutineCondition> RoutineCondition { get; set; }

        public virtual DbSet<BkashModel> BkashModel { get; set; }


        public virtual DbSet<AttendanceOfStudent> AttendanceOfStudent { get; set; }
        public virtual DbSet<AttendanceOfTeacher> AttendanceOfTeacher { get; set; }
        public virtual DbSet<AttendanceOfStaff> AttendanceOfStaff { get; set; }
        public virtual DbSet<ApplicationRole> ApplicationRole { get; set; }
        public virtual DbSet<ApplicationUserRole> ApplicationUserRole { get; set; }
    }
}
