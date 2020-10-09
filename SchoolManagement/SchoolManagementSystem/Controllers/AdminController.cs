using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Identity;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem.Controllers
{
    //[Route("api/[controller]")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _rollManager;
        private readonly IBranchRepository _branchRepo;
        public AdminController(IBranchRepository branchRepo, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> rollManager)
        {
            _branchRepo = branchRepo;
            _userManager = userManager;
            _rollManager = rollManager;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Branch>> GetBranch(int id)
        {
            try
            {
                var branch = await _branchRepo.GetBranch(id);

                if (branch == null)
                {
                    return NotFound();
                }
                return branch;
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }


        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> CreateBranch([FromBody] Branch branch)
        {
            if (ModelState.IsValid && branch.ConfirmPassword != null)
            {
                try
                {
                    Task<IdentityResult> roleResult;
                    //Check that there is an Administrator role and create if not
                    Task<bool> hasAdminRole = _rollManager.RoleExistsAsync(UserRoles.BranchAdmin);
                    hasAdminRole.Wait();
                    if (!hasAdminRole.Result)
                    {
                        ApplicationRole roleCreate = new ApplicationRole();
                        roleCreate.Name = UserRoles.BranchAdmin;
                        roleResult = _rollManager.CreateAsync(roleCreate);
                        roleResult.Wait();
                    }
                    //Check if the admin user exists and create it if not
                    Task<ApplicationUser> testUser = _userManager.FindByEmailAsync(branch.BranchName);
                    testUser.Wait();
                    if (testUser.Result == null)
                    {
                        ApplicationUser administrator = new ApplicationUser();
                        administrator.Email = branch.BranchName;
                        administrator.UserName = branch.BranchName;
                        Task<IdentityResult> newUser = _userManager.CreateAsync(administrator, branch.ConfirmPassword);
                        newUser.Wait();
                        if (newUser.Result.Succeeded)
                        {
                            Task<IdentityResult> newUserRole = _userManager.AddToRoleAsync(administrator, UserRoles.BranchAdmin);
                            newUserRole.Wait();

                            var branchRes = await _branchRepo.SaveBranch(branch);
                            if (branchRes != null)
                            {
                                return Ok(branchRes);
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
                    return BadRequest(ex);
                }
            }
            return BadRequest("Model State is not valid");
        }

        [HttpPut]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UpdateBranch([FromBody] Branch branch)
        {
            if (ModelState.IsValid && branch.Id != 0)
            {
                try
                {
                    Branch oldBranch = await _branchRepo.GetBranch(branch.Id);
                    if (oldBranch != null)
                    {
                        ApplicationUser ExisttUser = await _userManager.FindByEmailAsync(oldBranch.BranchName);
                        if (ExisttUser != null)
                        {
                            //ApplicationUser administrator = new ApplicationUser();
                            ExisttUser.Email = branch.BranchName;
                            ExisttUser.UserName = branch.BranchName;
                            Task<IdentityResult> newUser = _userManager.UpdateAsync(ExisttUser);
                            newUser.Wait();
                            if (newUser.Result.Succeeded)
                            {
                                //Task<IdentityResult> newUserRole = _userManager.AddToRoleAsync(administrator, UserRoles.BranchAdmin);
                                //newUserRole.Wait();

                                var branchRes = await _branchRepo.SaveBranch(branch);
                                if (branchRes != null)
                                {
                                    return Ok(branchRes);
                                }
                                else
                                {
                                    throw new NullReferenceException();
                                }

                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }

            }

            return BadRequest("Model State is not valid");
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteBranch(int id)
        {

            try
            {
                //var worker = await _context.Worker.FindAsync(id);
                Branch oldBranch = await _branchRepo.GetBranch(id);

                if (oldBranch == null)
                {
                    return NotFound();
                }
                ApplicationUser ExisttUser = await _userManager.FindByEmailAsync(oldBranch.BranchName);
                if (ExisttUser != null)
                {
                    IdentityResult result = await _userManager.DeleteAsync(ExisttUser);
                    if (result.Succeeded)
                    {
                        Branch branch = await _branchRepo.DeleteBranch(oldBranch.Id);
                        if (branch != null)
                        {
                            return Ok(branch);
                        }
                        throw new NullReferenceException();
                    }
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("Not found your Id");
        }
    }
}
