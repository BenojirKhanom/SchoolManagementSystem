using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Identity;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _rollManager;
        private readonly IConfiguration _configuration;
        public AccountController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> rollManager, IConfiguration configuration, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _rollManager = rollManager;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }



        public async Task<ActionResult<ApplicationUser>> ChangePassword(UserPasswordModel usermodel)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(usermodel.UserId);

            if (user == null)
            {
                return NotFound("User not valid");
            }
            bool yesFound = await _userManager.CheckPasswordAsync(user, usermodel.OldPassword);
            if (!yesFound)
            {
                return NotFound("Incorrect old Password");
            }           
            try
            {
                var RemoveResult = await _userManager.RemovePasswordAsync(user);
                if (RemoveResult.Succeeded)
                {
                    var AddResult = await _userManager.AddPasswordAsync(user, usermodel.ConfirmNewPassword);
                    if (AddResult.Succeeded)
                    {
                        return Ok("Successfully Change your Password.");
                    }
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return BadRequest("Unfortunately your Password Not Change.");   
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetUser()
        {
            return await _userManager.Users.ToListAsync();
        }
        // GET: api/Account/GetRole
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationRole>>> GetRole()
        {
            return await _context.Roles.ToListAsync();
        }

        // GET: api/Account/GetUserRole
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUserRole>>> GetUserRole()
        {
            return await _context.UserRoles.ToListAsync();
        }

        // GET: api/Account/GetRole/2
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationRole>> GetRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        [HttpPost("{name}")]
        public async Task<IActionResult> RollCreate(string name)
        {

            ApplicationRole role = new ApplicationRole()
            {
                Name = name,
                NormalizedName = name
            };
            IdentityResult result = await _rollManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return Ok("New Role Created");
            }
            return BadRequest("Sorry for failed");
        }

        [HttpDelete("{name}")]
        public async Task<ActionResult> RoleDelete(string name)
        {
            ApplicationRole role = await _rollManager.FindByNameAsync(name);

            if (role != null)
            {
                IdentityResult result = await _rollManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }


        // POST: 
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{email}")]
        public async Task<ActionResult<IEnumerable<List<ApplicationRole>>>> getRoleListForAssign(string email)
        {
            //ApplicationUser user = _context.Users.Where(w => w.Email == email).FirstOrDefault();
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                List<ApplicationRole> unassignedRole = new List<ApplicationRole>();
                List<ApplicationRole> assignedRole = new List<ApplicationRole>();
                foreach (ApplicationRole role in _rollManager.Roles)
                {
                    //bool res = await _userManager.IsInRoleAsync(user, role.Name);
                    if (await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        assignedRole.Add(role);
                    }
                    else
                    {
                        unassignedRole.Add(role);
                    }
                }
                return new List<List<ApplicationRole>> { assignedRole, unassignedRole };
            }
            return BadRequest();
        }


        public async Task<ActionResult> AssignRoleToUser(AddRoleToUser addRoleToUser)
        {
            var user = await _userManager.FindByIdAsync(addRoleToUser.UserId);
            var role = await _rollManager.FindByIdAsync(addRoleToUser.RoleId);

            var result = await _userManager.AddToRoleAsync(user, role.Name);

            if (result.Succeeded)
            {
                return Ok(user.UserName + " is Assigned to " + role.Name + " Role");
            }
            return BadRequest(result.Errors);
        }

    }
}
