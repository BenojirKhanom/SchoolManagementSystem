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
    public class StaffRepository : IStaffRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _rollManager;
        public StaffRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> rollManager)
        {
            _context = context;
            _userManager = userManager;
            _rollManager = rollManager;
        }

        public async Task<IEnumerable<Staff>> GetAllStaffByBranch(int branchId)
        {
            if(_context.Staff.Count() != 0)
            {
                return await _context.Staff.ToListAsync();
            }
            return null;
        }

        public async Task<Staff> GetStaff(int id)
        {
            if (StaffExists(id))
            {
                return await _context.Staff.FindAsync(id);
            }
            return null;
        }

        public async Task<Staff> AddStaff(Staff staff)
        {
            Staff thr = _context.Staff.Where(s => s.NationalIdNo == staff.NationalIdNo
                                                    || s.PhoneNo == staff.PhoneNo
                                                    || s.Email == staff.Email).FirstOrDefault();

            if (staff.Id == 0 && thr == null)
            {
                try
                {
                    
                    Task<IdentityResult> roleResult;
                    Task<bool> hasStaff = _rollManager.RoleExistsAsync(UserRoles.Staff);
                    hasStaff.Wait();
                    if (!hasStaff.Result)
                    {
                        ApplicationRole roleCreate = new ApplicationRole();
                        roleCreate.Name = UserRoles.Staff;
                        roleResult = _rollManager.CreateAsync(roleCreate);
                        roleResult.Wait();
                    }
                    Task<ApplicationUser> testUser = _userManager.FindByEmailAsync(staff.Email);
                    testUser.Wait();
                    if (testUser.Result == null)
                    {
                        ApplicationUser administrator = new ApplicationUser();
                        administrator.Email = staff.Email;
                        administrator.UserName = staff.Email;
                        Task<IdentityResult> newUser = _userManager.CreateAsync(administrator, staff.ConfirmPassword);
                        newUser.Wait();
                        if (newUser.Result.Succeeded)
                        {
                            Task<IdentityResult> newUserRole = _userManager.AddToRoleAsync(administrator, UserRoles.Staff);
                            newUserRole.Wait();

                            if (newUserRole.Result.Succeeded)
                            {
                                var a = await _context.Staff.AddAsync(staff);
                                _context.SaveChanges();
                                return staff;
                            }
                            else
                            {
                                throw new NullReferenceException();
                            }

                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return null;
        }

        public async Task<Staff> UpdateStaff(int id, Staff staff)
        {

            var oldStaff = _context.Staff.Where(w => w.Id == staff.Id).FirstOrDefault();
            if (oldStaff != null)
            {
                try
                {
                    ApplicationUser ExisttUser = await _userManager.FindByEmailAsync(oldStaff.Email);
                    if (ExisttUser != null)
                    {
                      
                        ExisttUser.Email = staff.Email;
                        ExisttUser.UserName = staff.Email;
                        Task<IdentityResult> newUser = _userManager.UpdateAsync(ExisttUser);
                        newUser.Wait();
                        if (newUser.Result.Succeeded)
                        {
                            oldStaff.FirstName = staff.FirstName;
                            oldStaff.LastName = staff.LastName;
                            oldStaff.DateOfBirth = staff.DateOfBirth;
                            oldStaff.Gender = staff.Gender;
                            oldStaff.Religion = staff.Religion;
                            oldStaff.PhoneNo = staff.PhoneNo;
                            oldStaff.NationalIdNo = staff.NationalIdNo;

                            if (staff.Email != null)
                            {
                                oldStaff.Email = staff.Email;
                            }
                            if (staff.ImageUrl != null)
                            {
                                oldStaff.ImageUrl = staff.ImageUrl;
                            }
                            oldStaff.FathersName = staff.FathersName;
                            oldStaff.MothersName = staff.MothersName;
                            oldStaff.MaritalStatus = staff.MaritalStatus;
                            oldStaff.IsPresent = staff.IsPresent;
                            oldStaff.PresentAddress = staff.PresentAddress;
                            oldStaff.ParmanentAddress = staff.ParmanentAddress;
                            oldStaff.JoiningDate = staff.JoiningDate;
                            oldStaff.ResignDate = staff.ResignDate;
                            oldStaff.CreatedDate = staff.CreatedDate;
                            oldStaff.BranchId = staff.BranchId;
                            oldStaff.DesignationId = staff.DesignationId;
                            oldStaff.PostOfficeId = staff.PostOfficeId;

                            _context.Staff.Update(oldStaff);
                            _context.SaveChanges();

                            return oldStaff;
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
        public async Task<Staff> DeleteStaff(int id)
        {   
            try
            {

                Staff existStaff = await _context.Staff.FindAsync(id);
                if (existStaff == null)
                {
                    return null;
                }
                ApplicationUser ExisttUser = await _userManager.FindByEmailAsync(existStaff.Email);
                if (ExisttUser != null)
                {
                    IdentityResult result = await _userManager.DeleteAsync(ExisttUser);
                    if (result.Succeeded)
                    {
                        _context.Staff.Remove(existStaff);
                        _context.SaveChanges();
                        return existStaff;
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
        public bool StaffExists(int id)
        {
            return _context.Staff.Any(e => e.Id == id);
        }

        public IEnumerable<Staff> GetAllStaffByDesignation(int BranchId, int designatonId)
        {

            return _context.Staff.Where(b => b.BranchId == BranchId && b.DesignationId == designatonId && (b.ResignDate == null || b.ResignDate >= DateTime.Now)).ToList();
        }

        
        public async Task<Staff> EditStaffProfile(int id, Staff staff)
        {

            var oldStaff = _context.Staff.Where(w => w.Id == staff.Id).FirstOrDefault();
            if (oldStaff != null)
            {
                try
                {
                    ApplicationUser ExisttUser = await _userManager.FindByEmailAsync(oldStaff.Email);
                    if (ExisttUser != null)
                    {
                        
                        ExisttUser.Email = staff.Email;
                        ExisttUser.UserName = staff.Email;
                        Task<IdentityResult> newUser = _userManager.UpdateAsync(ExisttUser);
                        newUser.Wait();
                        if (newUser.Result.Succeeded)
                        {
                           
                            oldStaff.Religion = staff.Religion;
                            oldStaff.PhoneNo = staff.PhoneNo;
                           
                            
                            if (staff.ImageUrl != null)
                            {
                                oldStaff.ImageUrl = staff.ImageUrl;
                            }
                           
                            oldStaff.MaritalStatus = staff.MaritalStatus;
                            oldStaff.PresentAddress = staff.PresentAddress;
                            oldStaff.PostOfficeId = staff.PostOfficeId;

                            _context.Staff.Update(oldStaff);
                            _context.SaveChanges();

                            return oldStaff;
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

        public IEnumerable<Staff> GetAllStaffCheckResign(int branchId)
        {
            var StaffList = _context.Staff.Where(te => te.BranchId == branchId && te.IsPresent == false && (te.ResignDate != null || te.ResignDate <= DateTime.Now)).ToList();
            if (StaffList != null)
            {
                return StaffList;
            }
            return null;
        }

        public IEnumerable<Staff> GetBranchWiseActiveStaff(int branchId)
        {
            var StaffList = _context.Staff.Where(te => te.BranchId == branchId && te.IsPresent == true).ToList();
            if (StaffList != null)
            {
                return StaffList;
            }
            return null;
        }
    }
}
