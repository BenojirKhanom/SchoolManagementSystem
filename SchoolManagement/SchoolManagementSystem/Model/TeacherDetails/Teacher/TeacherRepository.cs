using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _rollManager;
        public TeacherRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> rollManager)
        {
            _context = context;
            _userManager = userManager;
            _rollManager = rollManager;
        }



        public async Task<Teacher> AddTeacher(Teacher teacher)
        {
            Teacher thr = _context.Teacher.Where(t => t.NationalIdNo == teacher.NationalIdNo
                                                    || t.PhoneNo == teacher.PhoneNo
                                                    || t.Email == teacher.Email).FirstOrDefault();
            if (teacher.Id == 0 && thr == null)
            {
                try
                {
                    Task<IdentityResult> roleResult;
                    //Check that there is an Administrator role and create if not
                    Task<bool> hasTeacherRole = _rollManager.RoleExistsAsync(UserRoles.Teacher);
                    hasTeacherRole.Wait();
                    if (!hasTeacherRole.Result)
                    {
                        ApplicationRole roleCreate = new ApplicationRole();
                        roleCreate.Name = UserRoles.Teacher;
                        roleResult = _rollManager.CreateAsync(roleCreate);
                        roleResult.Wait();
                    }
                    //Check if the admin user exists and create it if not
                    Task<ApplicationUser> testUser = _userManager.FindByEmailAsync(teacher.Email);
                    testUser.Wait();
                    if (testUser.Result == null)
                    {
                        ApplicationUser administrator = new ApplicationUser();
                        administrator.Email = teacher.Email;
                        administrator.UserName = teacher.Email;
                        Task<IdentityResult> newUser = _userManager.CreateAsync(administrator, teacher.ConfirmPassword);
                        newUser.Wait();
                        if (newUser.Result.Succeeded)
                        {
                            Task<IdentityResult> newUserRole = _userManager.AddToRoleAsync(administrator, UserRoles.Teacher);
                            newUserRole.Wait();

                            if (newUserRole.Result.Succeeded)
                            {
                                var a = await _context.Teacher.AddAsync(teacher);
                                _context.SaveChanges();
                                return teacher;
                            }
                            else
                            {
                                throw new NullReferenceException();
                            }

                        }
                    }
                }
                catch (Exception)
                {
                    return null;
                }

            }
            return null;
        }
        public async Task<Teacher> UpdateTeacher(int id, Teacher teacher)
        {
            Teacher existTeacher = _context.Teacher.Where(t => t.Id == id).FirstOrDefault();
            if (existTeacher != null)
            {
                try
                {
                    ApplicationUser ExisttUser = await _userManager.FindByEmailAsync(existTeacher.Email);
                    if (ExisttUser != null)
                    {
                        //ApplicationUser administrator = new ApplicationUser();
                        ExisttUser.Email = teacher.Email;
                        ExisttUser.UserName = teacher.Email;
                        Task<IdentityResult> newUser = _userManager.UpdateAsync(ExisttUser);
                        newUser.Wait();
                        if (newUser.Result.Succeeded)
                        {
                            //Update that educationSystem
                            existTeacher.FirstName = teacher.FirstName;
                            existTeacher.LastName = teacher.LastName;
                            existTeacher.DateOfBirth = teacher.DateOfBirth;                            
                            existTeacher.Gender = teacher.Gender;
                            existTeacher.Religion = teacher.Religion;

                            existTeacher.PhoneNo = teacher.PhoneNo;
                            existTeacher.NationalIdNo = teacher.NationalIdNo;
                            existTeacher.Email = teacher.Email;      
                            
                            if (teacher.ImageUrl != null)
                            {
                                existTeacher.ImageUrl = teacher.ImageUrl;
                            }
                            existTeacher.IsPresent = teacher.IsPresent;
                            existTeacher.CreatedDate = teacher.CreatedDate;
                            existTeacher.FathersName = teacher.FathersName;
                            existTeacher.MothersName = teacher.MothersName;
                            existTeacher.MaritalStatus = teacher.MaritalStatus;
                            existTeacher.JoiningDate = teacher.JoiningDate;
                            existTeacher.ResignDate = teacher.ResignDate;
                            existTeacher.BranchId = teacher.BranchId;
                            existTeacher.DesignationId = teacher.DesignationId;
                            //teacher1.SubjectId = teacher.SubjectId;

                            _context.Teacher.Update(existTeacher);
                            _context.SaveChanges();

                            return existTeacher;
                        }
                        else
                        {
                            throw new NullReferenceException();
                        }
                        
                    }               
                }
                catch (Exception)
                {
                    return null; 
                }
            }
            return null;
        }
    
        public async Task<Teacher> DeleteTeacher(int id)
        {
            try
            {                
                Teacher existTeacher = await _context.Teacher.FindAsync(id);
                if (existTeacher == null)
                {
                    return null;
                }
                ApplicationUser ExisttUser = await _userManager.FindByEmailAsync(existTeacher.Email);
                if (ExisttUser != null)
                {
                    IdentityResult result = await _userManager.DeleteAsync(ExisttUser);
                    if (result.Succeeded)
                    {
                        _context.Teacher.Remove(existTeacher);
                        _context.SaveChanges();
                        return existTeacher;                      
                    }
                    throw new NullReferenceException();
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }

        private bool TeacherExists(int id)
        {
            return _context.Teacher.Any(e => e.Id == id);
        }

        public async Task<IEnumerable<Teacher>> GetAllTeacherByBranch(int branchId)
        {
            var teacherList  = await _context.Teacher.Where(e => e.BranchId == branchId).ToListAsync();
            if (teacherList != null)
            {
                return teacherList;
            }
            return null;
        }
        public async Task<Teacher> GetTeacherByID(int id)
        {
            var teacher = await _context.Teacher.FindAsync(id);
            if (teacher != null)
            {            
                return teacher;
            }
            return null;
        }
      
        public IEnumerable<Teacher> GetSubjectWiseTeacherForBranch(int branchId, int subjectId)
        {
            List<Teacher> teacherList = new List<Teacher>();
            var subjectTeacher = _context.SubjectTeacher.Where(a => a.SubjectId == subjectId).ToList();
            if(subjectTeacher != null)
            {
                foreach (SubjectTeacher st in subjectTeacher)
                {
                    var teacher = _context.Teacher.Where(t => t.Id == st.TeacherId && t.BranchId == branchId).FirstOrDefault();
                    if (teacher != null)
                    {
                        teacherList.Add(teacher);
                    }
                }
                return teacherList;
            }
            return null;
        }

        public IEnumerable<Teacher> GetBranchWiseActiveTeacher(int branchId)
        {
            var teacherList = _context.Teacher.Where(te => te.BranchId == branchId && te.IsPresent == true).ToList();
            if (teacherList != null)
            {
                return teacherList;
            }
            return null;
        }

        public IEnumerable<Teacher> GetAllTeacherCheckResign(int branchId)
        {
            var teacherList = _context.Teacher.Where(te => te.BranchId == branchId && te.IsPresent == false).ToList();
            if (teacherList != null)
            {
                return teacherList;
            }
            return null;
        }

        public async Task<SubjectTeacher> AddSubjectTeacher(SubjectTeacher subjectTeacher)
        {
            var exist =  _context.SubjectTeacher.Where(s => s.TeacherId == subjectTeacher.TeacherId
                                                        && s.SubjectId == subjectTeacher.SubjectId).FirstOrDefault();
            if(exist == null)
            {
                var res =await _context.SubjectTeacher.AddAsync(subjectTeacher);
                _context.SaveChanges();
                return subjectTeacher;
            }
            return null;
        }

        public async Task<SubjectTeacher> DeleteSubjectTeacher(int id)
        {
            var exist = await _context.SubjectTeacher.Where(i => i.Id == id).FirstOrDefaultAsync();
            if (exist != null)
            {
                 _context.SubjectTeacher.Remove(exist);
                 _context.SaveChanges();
                return exist;
            }
            return null;
        }
    }
}
