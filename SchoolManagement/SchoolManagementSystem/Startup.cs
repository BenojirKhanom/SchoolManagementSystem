using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchoolManagementSystem.Identity;
using SchoolManagementSystem.Model;
using System;
using System.Threading.Tasks;
using SchoolManagementSystem.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Http.Features;

namespace SchoolManagementSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();

            //for Entity Freamwork
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings ffff
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 2;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            });
            //for Identity
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Adding Authentication  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });

            //for call from another project
            services.AddCors();
            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });


            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //Zulhas
            services.AddScoped(typeof(IShiftRepository), typeof(ShiftRepository));
            services.AddScoped(typeof(ISchoolClassRepository), typeof(SchoolClassRepository));
            services.AddScoped(typeof(ISchoolVersionRepository), typeof(SchoolVersionRepository));
            services.AddScoped(typeof(ISectionRepository), typeof(SectionRepository));
            services.AddScoped(typeof(IRoomRepository), typeof(RoomRepository));
            services.AddScoped(typeof(IBranchClassRepository), typeof(BranchClassRepository));

            //Robiul
            services.AddScoped(typeof(IExamRepository), typeof(ExamRepository));
            services.AddScoped(typeof(IExamRoutineRepository), typeof(ExamRoutineRepository));
            services.AddScoped(typeof(IExamResultRepository), typeof(ExamResultRepository));
            services.AddScoped(typeof(IExamMarkRepository), typeof(ExamMarkRepository));
            services.AddScoped(typeof(IExamResultPointRepository), typeof(ExamResultPointRepository));

            services.AddScoped(typeof(IAttendanceOfStudentRepository), typeof(AttendanceOfStudentRepository));

            //Alauddin Jafor
            services.AddScoped(typeof(IBranchRepository), typeof(BranchRepository));
            services.AddScoped(typeof(ITeacherRepository), typeof(TeacherRepository));

            services.AddScoped(typeof(IStudentRepository), typeof(StudentRepository));
            services.AddScoped(typeof(IDesignationRepository), typeof(DesignationRepository));
            
            services.AddScoped(typeof(IStaffRepository), typeof(StaffRepository));
            services.AddScoped(typeof(IQuotaRepository), typeof(QuotaRepository));
            services.AddScoped(typeof(IApplicationFormRepository), typeof(ApplicationFormRepository));


            services.AddScoped(typeof(ISubjectRepository), typeof(SubjectRepository));
            services.AddScoped(typeof(IGroupRepository), typeof(GroupRepository));

            services.AddScoped(typeof(IClassRoutineRepository), typeof(ClassRoutineRepository));

            services.AddScoped(typeof(ICountryRepository), typeof(CountryRepository));
            services.AddScoped(typeof(INoticeBoardRepository), typeof(NoticeBoardRepository));

            services.AddScoped(typeof(IRulesRegulationRepository), typeof(RulesRegulationRepository));
            services.AddScoped(typeof(IPoliceStationRepository), typeof(PoliceStationRepository));
            services.AddScoped(typeof(IPostOfficeRepository), typeof(PostOfficeRepository));
            services.AddScoped(typeof(IEventRepository), typeof(EventRepository));

            services.AddScoped(typeof(IHolidayRepository), typeof(HolidayRepository));
            services.AddScoped(typeof(IStudentSubjectRepository), typeof(StudentSubjectRepository));

            services.AddScoped(typeof(IStaffTaskRepository), typeof(StaffTaskRepository));
            services.AddScoped(typeof(ITaskRoutineRepository), typeof(TaskRoutineRepository));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            //using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            //{
            //    var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            //    context.Database.Migrate();
            //}

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            CreateRoles(serviceProvider);
        }




        private void CreateRoles(IServiceProvider serviceProvider)
        {


            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            Task<IdentityResult> roleResult;
            string email = "admin@gmail.com";
            string username = "admin";

            //Check that there is an Administrator role and create if not
            Task<bool> hasAdminRole = roleManager.RoleExistsAsync(UserRoles.Admin);
            hasAdminRole.Wait();

            if (!hasAdminRole.Result)
            {
                ApplicationRole roleCreate = new ApplicationRole();
                roleCreate.Name = UserRoles.Admin;
                roleResult = roleManager.CreateAsync(roleCreate);
                roleResult.Wait();
            }

            //Check if the admin user exists and create it if not
            //Add to the Administrator role

            Task<ApplicationUser> testUser = userManager.FindByEmailAsync(email);
            testUser.Wait();

            if (testUser.Result == null)
            {
                ApplicationUser administrator = new ApplicationUser();
                administrator.Email = email;
                administrator.UserName = username;

                Task<IdentityResult> newUser = userManager.CreateAsync(administrator, "1234");
                newUser.Wait();

                if (newUser.Result.Succeeded)
                {
                    Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(administrator, UserRoles.Admin);
                    newUserRole.Wait();
                }


            }


            //create New Role BranchAdmin
            Task<IdentityResult> roleResult0;
            //Check that there is an BranchAdmin role and create if not
            Task<bool> hasBranchAdminRole = roleManager.RoleExistsAsync(UserRoles.BranchAdmin);
            hasBranchAdminRole.Wait();

            if (!hasBranchAdminRole.Result)
            {
                ApplicationRole roleCreate = new ApplicationRole();
                roleCreate.Name = UserRoles.BranchAdmin;
                roleResult0 = roleManager.CreateAsync(roleCreate);
                roleResult0.Wait();
            }



            //create New Role Student
            Task<IdentityResult> roleResult1;
            //Check that there is an Student role and create if not
            Task<bool> hasStudentRole = roleManager.RoleExistsAsync(UserRoles.Student);
            hasStudentRole.Wait();

            if (!hasStudentRole.Result)
            {
                ApplicationRole roleCreate = new ApplicationRole();
                roleCreate.Name = UserRoles.Student;
                roleResult1 = roleManager.CreateAsync(roleCreate);
                roleResult1.Wait();
            }



            //create New Role Teacher
            Task<IdentityResult> roleResult2;
            //Check that there is an Teacher role and create if not
            Task<bool> hasTeacherRole = roleManager.RoleExistsAsync(UserRoles.Teacher);
            hasTeacherRole.Wait();

            if (!hasTeacherRole.Result)
            {
                ApplicationRole roleCreate = new ApplicationRole();
                roleCreate.Name = UserRoles.Teacher;
                roleResult2 = roleManager.CreateAsync(roleCreate);
                roleResult2.Wait();
            }



            //create New Role Staff
            Task<IdentityResult> roleResult3;
            //Check that there is an Staff role and create if not
            Task<bool> hasStaffRole = roleManager.RoleExistsAsync(UserRoles.Staff);
            hasStaffRole.Wait();

            if (!hasStaffRole.Result)
            {
                ApplicationRole roleCreate = new ApplicationRole();
                roleCreate.Name = UserRoles.Staff;
                roleResult3 = roleManager.CreateAsync(roleCreate);
                roleResult3.Wait();
            }
        }
    }
}

