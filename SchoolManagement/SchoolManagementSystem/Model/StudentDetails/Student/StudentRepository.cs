using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolManagementSystem.Model;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;

namespace SchoolManagementSystem
{
    public class StudentRepository : IStudentRepository
    {
        ApplicationDbContext _context;
        IApplicationFormRepository _applicationFormrepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _rollManager;
        public StudentRepository(ApplicationDbContext context, IApplicationFormRepository applicationFormrepo, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> rollManager)
        {
            _context = context;
            _applicationFormrepo = applicationFormrepo;
            _userManager = userManager;
            _rollManager = rollManager;

        }



        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }


        // Get All Student List
        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            if (_context != null)
            {
                return await _context.Student.ToListAsync();
            }
            return null;
        }



        // 1. Get Student By Id
        public async Task<Student> GetStudent(int id)
        {
            if (StudentExists(id))
            {
                return await _context.Student.FirstOrDefaultAsync(s => s.Id == id);
            }
            return null;
        }



        // 2. Get Student Information By StudentIdNo
        public async Task<Student> GetStudentInfo(string studentId)
        {
            if (_context != null)
            {
                return await _context.Student.Where(s => s.StudentIdNo == studentId).FirstOrDefaultAsync();
            }
            return null;
        }





        // 3. Insert Data Into Student Table From ApplicationForm Table If applicantId && IsAdmitted true
        public async Task<Student> SaveStudent(string applicantId)
        {
            if (_context != null)
            {
                // Find applicantId  in ApplicationForm table
                ApplicationForm dbEntry = _context.ApplicationForm.Where(a => a.ApplicantId == applicantId && a.IsSelected == true && a.IsAdmitted == true).FirstOrDefault();

                if (dbEntry != null)
                {
                    // Find StudentIdNo already exit in Student Table
                    Student studentExists = _context.Student.Where(s => s.StudentIdNo == dbEntry.ApplicantId).FirstOrDefault();

                    if (studentExists == null)
                    {
                        try
                        {
                            Student student = new Student()
                            {
                                StudentIdNo = dbEntry.ApplicantId,
                                FirstName = dbEntry.FirstName,
                                LastName = dbEntry.LastName,
                                DateOfBirth = dbEntry.DateOfBirth,
                                Gender = dbEntry.Gender,
                                Religion = dbEntry.Religion,
                                BirthRegistrationNo = dbEntry.BirthRegistrationNo,
                                ImageUrl = dbEntry.ImageUrl,
                                FatherName = dbEntry.FatherName,
                                FatherPhone = dbEntry.FatherPhone,
                                FatherOccupation = dbEntry.FatherOccupation,
                                MotherName = dbEntry.MotherName,
                                MotherPhone = dbEntry.MotherPhone,
                                MotherOccupation = dbEntry.MotherOccupation,
                                MonthlyFamillyIncome = dbEntry.MonthlyFamillyIncome,
                                FormarSchoolName = dbEntry.FormarSchoolName,
                                AdmissionDate = DateTime.UtcNow,
                                QuotaId = dbEntry.QuotaId,
                                PresentAddress = dbEntry.PresentAddress,
                                ParmanentAddress = dbEntry.ParmanentAddress,
                                PostOfficeId = dbEntry.PostOfficeId,

                                Password = "12345",
                                ConfirmPassword = "12345"
                            };
                            _context.Student.Add(student);
                            try
                            {
                                ApplicationUser user = new ApplicationUser()
                                {
                                    UserName = student.StudentIdNo,
                                    FirstName = student.FirstName,
                                    LastName = student.LastName,
                                    PasswordHash = student.Password
                                };
                                IdentityResult result = await _userManager.CreateAsync(user, student.ConfirmPassword);
                                if (result.Succeeded)
                                {
                                    Task<IdentityResult> roleResult;
                                    //Check that there is an Administrator role and create if not
                                    Task<bool> hasStudentRole = _rollManager.RoleExistsAsync(UserRoles.Student);
                                    hasStudentRole.Wait();
                                    if (!hasStudentRole.Result)
                                    {
                                        ApplicationRole roleCreate = new ApplicationRole();
                                        roleCreate.Name = UserRoles.Student;
                                        roleResult = _rollManager.CreateAsync(roleCreate);
                                        roleResult.Wait();
                                    }
                                    Task<IdentityResult> newUserRole = _userManager.AddToRoleAsync(user, UserRoles.Student);
                                    newUserRole.Wait();
                                    try
                                    {
                                        //Commit the transaction
                                        await _context.SaveChangesAsync();
                                    }
                                    catch (Exception ex)
                                    {
                                        throw ex;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            return student;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    return null;
                }
                return null;
            }
            return null;
        }




        // 4. Update Student
        public async Task<int> UpdateStudent(Student student)
        {
            if (_context != null)
            {
                var dbEntry = _context.Student.Where(s => s.Id == student.Id).FirstOrDefault();

                if (dbEntry != null)
                {
                    _context.Entry(dbEntry).Property(p => p.StudentIdNo).IsModified = false;
                    _context.Entry(dbEntry).Property(p => p.FullName).IsModified = false;
                    _context.Entry(dbEntry).Property(p => p.AdmissionDate).IsModified = false;

                    ApplicationUser userStudent = _context.Users.Where(s => s.UserName == dbEntry.StudentIdNo).FirstOrDefault();

                    if (userStudent != null)
                    {
                        userStudent.UserName = dbEntry.StudentIdNo;
                        userStudent.FirstName = student.FirstName;
                        userStudent.LastName = student.LastName;
                    };
                    IdentityResult result = await _userManager.UpdateAsync(userStudent);

                    if (result.Succeeded)
                    {
                        dbEntry.FirstName = student.FirstName;
                        dbEntry.LastName = student.LastName;
                        dbEntry.DateOfBirth = student.DateOfBirth;
                        dbEntry.RollNo = student.RollNo;
                        dbEntry.Gender = student.Gender;
                        dbEntry.Religion = student.Religion;
                        dbEntry.BirthRegistrationNo = student.BirthRegistrationNo;
                        dbEntry.ImageUrl = student.ImageUrl;
                        dbEntry.FatherName = student.FatherName;
                        dbEntry.FatherOccupation = student.FatherOccupation;
                        dbEntry.FatherPhone = student.FatherPhone;
                        dbEntry.MotherName = student.MotherName;
                        dbEntry.MotherName = student.MotherName;
                        dbEntry.MotherPhone = student.MotherPhone;
                        dbEntry.MonthlyFamillyIncome = student.MonthlyFamillyIncome;
                        dbEntry.FormarSchoolName = student.FormarSchoolName;
                        dbEntry.GuardianName = student.GuardianName;
                        dbEntry.GuardianPhoneNo = student.GuardianPhoneNo;
                        dbEntry.RelationOfAltGuardian = student.RelationOfAltGuardian;
                        dbEntry.QuotaId = student.QuotaId;
                        dbEntry.PostOfficeId = student.PostOfficeId;

                        //Update that Student
                        _context.Student.Update(dbEntry);
                    }
                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    return dbEntry.Id;
                }
                return 0;
            }
            return 0;
        }



        // 5. Delete Student
        public async Task<Student> DeleteStudent(int id)
        {
            try
            {
                // Find Student is already exit in database?
                Student dbEntry = _context.Student.Find(id);

                if (dbEntry != null)
                {
                    ApplicationUser userStudent = _context.Users.Where(s => s.UserName == dbEntry.StudentIdNo).FirstOrDefault();

                    if (userStudent != null)
                    {
                        IdentityResult result = await _userManager.DeleteAsync(userStudent);
                        if (result.Succeeded)
                        {
                            var student = _context.Student.First(s => s.Id == dbEntry.Id);
                        }
                        //Delete that Student
                        _context.Student.Remove(dbEntry);
                        try
                        {
                            //Commit the transaction
                            await _context.SaveChangesAsync();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        return dbEntry;
                    }
                    return null;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        // 6. Get Class Wise Student List
        public IEnumerable<Student> GetClassWiseStudentList(int branchId, int classId)
        {
            try
            {
                List<Student> studentList = new List<Student>();

                var branchClassList = _context.BranchClass.Where(b => b.BranchId == branchId && b.SchoolClassId == classId).ToList();
                if (branchClassList.Count() > 0)
                {
                    foreach (BranchClass bcl in branchClassList)
                    {
                        var section = _context.Section.Where(s => s.BranchClassId == bcl.Id).ToList();
                        if (section.Count() > 0)
                        {
                            foreach (Section sc in section)
                            {
                                var students = _context.Student.Where(s => s.SectionId == sc.Id).ToList();
                                if (students.Count() > 0)
                                {
                                    studentList.AddRange(students);
                                }
                            }
                        }
                        else
                        {
                            return null;
                        }
                    }
                    return studentList;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
