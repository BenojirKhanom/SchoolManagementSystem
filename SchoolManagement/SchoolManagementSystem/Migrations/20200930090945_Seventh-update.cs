using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class Seventhupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    CountryCode = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Designation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Holiday",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HolidayName = table.Column<string>(maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    NumberOfDay = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holiday", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quota",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuotaName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quota", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoutineCondition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutineCondition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolClass",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(maxLength: 50, nullable: false),
                    NumberOfSubject = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolVersion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolVersionName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolVersion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftName = table.Column<string>(maxLength: 50, nullable: true),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffTask",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 700, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffTask", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Division",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivisionName = table.Column<string>(maxLength: 100, nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Division_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(maxLength: 100, nullable: false),
                    SubjectCode = table.Column<string>(maxLength: 6, nullable: false),
                    CanBeOptional = table.Column<bool>(nullable: false),
                    DownloadLink = table.Column<string>(maxLength: 1000, nullable: true),
                    SchoolClassId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: true),
                    SchoolVersionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subject_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subject_SchoolClass_SchoolClassId",
                        column: x => x.SchoolClassId,
                        principalTable: "SchoolClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subject_SchoolVersion_SchoolVersionId",
                        column: x => x.SchoolVersionId,
                        principalTable: "SchoolVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(maxLength: 100, nullable: true),
                    DivisionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_District_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoliceStation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationName = table.Column<string>(maxLength: 100, nullable: false),
                    DistrictId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliceStation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoliceStation_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostOffice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostOfficeName = table.Column<string>(maxLength: 100, nullable: false),
                    PoliceStationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostOffice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostOffice_PoliceStation_PoliceStationId",
                        column: x => x.PoliceStationId,
                        principalTable: "PoliceStation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(maxLength: 200, nullable: false),
                    Location = table.Column<string>(maxLength: 200, nullable: false),
                    Authority = table.Column<string>(maxLength: 200, nullable: false),
                    PostOfficeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branch_PostOffice_PostOfficeId",
                        column: x => x.PostOfficeId,
                        principalTable: "PostOffice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchClass",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(nullable: false),
                    ShiftId = table.Column<int>(nullable: false),
                    SchoolVersionId = table.Column<int>(nullable: false),
                    SchoolClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchClass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchClass_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchClass_SchoolClass_SchoolClassId",
                        column: x => x.SchoolClassId,
                        principalTable: "SchoolClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchClass_SchoolVersion_SchoolVersionId",
                        column: x => x.SchoolVersionId,
                        principalTable: "SchoolVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchClass_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shift",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(maxLength: 200, nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    EventControlar = table.Column<string>(maxLength: 100, nullable: false),
                    Venue = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    BranchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamType = table.Column<string>(maxLength: 100, nullable: false),
                    ExamDiscription = table.Column<string>(maxLength: 200, nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    PassingRate = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    BranchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exam_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamResultPoint",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaximumMark = table.Column<int>(nullable: false),
                    MinimumMark = table.Column<int>(nullable: false),
                    Point = table.Column<double>(nullable: false),
                    Grade = table.Column<string>(maxLength: 2, nullable: false),
                    Note = table.Column<string>(maxLength: 500, nullable: false),
                    BranchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamResultPoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamResultPoint_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoticeBoard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicName = table.Column<string>(maxLength: 100, nullable: false),
                    NoticeBody = table.Column<string>(nullable: false),
                    PublishDate = table.Column<DateTime>(type: "date", nullable: false),
                    BranchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeBoard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoticeBoard_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(maxLength: 10, nullable: false),
                    RoomType = table.Column<string>(maxLength: 100, nullable: false),
                    SitCapacity = table.Column<int>(nullable: false),
                    FloorNumber = table.Column<int>(nullable: false),
                    BlockName = table.Column<string>(maxLength: 10, nullable: false),
                    BranchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RulesRegulation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RuleDetails = table.Column<string>(maxLength: 1000, nullable: false),
                    BranchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RulesRegulation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RulesRegulation_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Religion = table.Column<int>(nullable: false),
                    PhoneNo = table.Column<string>(maxLength: 15, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    NationalIdNo = table.Column<string>(maxLength: 30, nullable: false),
                    ImageUrl = table.Column<string>(maxLength: 1000, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    FathersName = table.Column<string>(maxLength: 100, nullable: false),
                    MothersName = table.Column<string>(maxLength: 100, nullable: false),
                    MaritalStatus = table.Column<bool>(nullable: false),
                    IsPresent = table.Column<bool>(nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "date", nullable: false),
                    ResignDate = table.Column<DateTime>(type: "date", nullable: true),
                    PresentAddress = table.Column<string>(maxLength: 500, nullable: false),
                    ParmanentAddress = table.Column<string>(maxLength: 500, nullable: false),
                    FingerData = table.Column<string>(nullable: true),
                    PostOfficeId = table.Column<int>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    DesignationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Staff_Designation_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Staff_PostOffice_PostOfficeId",
                        column: x => x.PostOfficeId,
                        principalTable: "PostOffice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Religion = table.Column<int>(nullable: false),
                    PhoneNo = table.Column<string>(maxLength: 15, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    NationalIdNo = table.Column<string>(maxLength: 30, nullable: false),
                    IsPresent = table.Column<bool>(nullable: false),
                    ImageUrl = table.Column<string>(maxLength: 1000, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    MaritalStatus = table.Column<bool>(nullable: false),
                    FathersName = table.Column<string>(maxLength: 100, nullable: false),
                    MothersName = table.Column<string>(maxLength: 100, nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "date", nullable: false),
                    ResignDate = table.Column<DateTime>(type: "date", nullable: true),
                    FingerData = table.Column<string>(nullable: true),
                    BranchId = table.Column<int>(nullable: false),
                    DesignationId = table.Column<int>(nullable: true),
                    PostOfficeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teacher_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teacher_Designation_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teacher_PostOffice_PostOfficeId",
                        column: x => x.PostOfficeId,
                        principalTable: "PostOffice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationForm",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Religion = table.Column<int>(nullable: false),
                    BirthRegistrationNo = table.Column<string>(maxLength: 20, nullable: false),
                    ImageUrl = table.Column<string>(maxLength: 1000, nullable: false),
                    ApplingDate = table.Column<DateTime>(type: "date", nullable: false),
                    FatherName = table.Column<string>(maxLength: 50, nullable: false),
                    FatherOccupation = table.Column<string>(maxLength: 50, nullable: false),
                    FatherPhone = table.Column<string>(maxLength: 15, nullable: false),
                    MotherName = table.Column<string>(maxLength: 50, nullable: false),
                    MotherOccupation = table.Column<string>(maxLength: 50, nullable: false),
                    MotherPhone = table.Column<string>(maxLength: 15, nullable: false),
                    MonthlyFamillyIncome = table.Column<int>(nullable: false),
                    FormarSchoolName = table.Column<string>(maxLength: 200, nullable: true),
                    IsSelected = table.Column<bool>(nullable: false),
                    IsAdmitted = table.Column<bool>(nullable: false),
                    PresentAddress = table.Column<string>(maxLength: 500, nullable: false),
                    ParmanentAddress = table.Column<string>(maxLength: 500, nullable: false),
                    PostOfficeId = table.Column<int>(nullable: false),
                    QuotaId = table.Column<int>(nullable: true),
                    BranchClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationForm_BranchClass_BranchClassId",
                        column: x => x.BranchClassId,
                        principalTable: "BranchClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationForm_PostOffice_PostOfficeId",
                        column: x => x.PostOfficeId,
                        principalTable: "PostOffice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationForm_Quota_QuotaId",
                        column: x => x.QuotaId,
                        principalTable: "Quota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExamRoutine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamDate = table.Column<DateTime>(type: "date", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Duration = table.Column<string>(maxLength: 100, nullable: true),
                    TotalNumber = table.Column<int>(nullable: false),
                    BranchClassId = table.Column<int>(nullable: false),
                    ExamId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamRoutine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamRoutine_BranchClass_BranchClassId",
                        column: x => x.BranchClassId,
                        principalTable: "BranchClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamRoutine_Exam_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamRoutine_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceOfStaff",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    InTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    OutTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    StaffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceOfStaff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceOfStaff_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskRoutine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    StaffTaskId = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskRoutine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskRoutine_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskRoutine_StaffTask_StaffTaskId",
                        column: x => x.StaffTaskId,
                        principalTable: "StaffTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceOfTeacher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    InTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    OutTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceOfTeacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceOfTeacher_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionName = table.Column<string>(maxLength: 20, nullable: false),
                    GroupId = table.Column<int>(nullable: true),
                    BranchClassId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: true),
                    TeacherId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Section_BranchClass_BranchClassId",
                        column: x => x.BranchClassId,
                        principalTable: "BranchClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Section_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Section_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Section_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectTeacher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTeacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassRoutine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWeek = table.Column<string>(maxLength: 15, nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ClassDuration = table.Column<string>(maxLength: 100, nullable: false),
                    PeriodNumber = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: true),
                    SectionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRoutine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassRoutine_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassRoutine_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassRoutine_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassRoutine_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentIdNo = table.Column<string>(nullable: false),
                    RollNo = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FullName = table.Column<string>(maxLength: 101, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    BirthRegistrationNo = table.Column<string>(maxLength: 20, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Religion = table.Column<int>(nullable: false),
                    BloodGroup = table.Column<int>(nullable: true),
                    ImageUrl = table.Column<string>(maxLength: 1000, nullable: false),
                    FatherName = table.Column<string>(maxLength: 500, nullable: false),
                    FatherOccupation = table.Column<string>(maxLength: 50, nullable: false),
                    FatherPhone = table.Column<string>(maxLength: 15, nullable: false),
                    MotherName = table.Column<string>(maxLength: 50, nullable: false),
                    MotherOccupation = table.Column<string>(maxLength: 50, nullable: false),
                    MotherPhone = table.Column<string>(maxLength: 15, nullable: false),
                    MonthlyFamillyIncome = table.Column<int>(nullable: false),
                    FormarSchoolName = table.Column<string>(maxLength: 200, nullable: true),
                    GuardianName = table.Column<string>(maxLength: 50, nullable: true),
                    GuardianPhoneNo = table.Column<string>(maxLength: 15, nullable: true),
                    GuardianEmail = table.Column<string>(nullable: true),
                    RelationOfAltGuardian = table.Column<string>(maxLength: 100, nullable: true),
                    AdmissionDate = table.Column<DateTime>(type: "date", nullable: false),
                    PresentAddress = table.Column<string>(nullable: false),
                    ParmanentAddress = table.Column<string>(maxLength: 500, nullable: false),
                    FingerData = table.Column<string>(nullable: true),
                    PostOfficeId = table.Column<int>(nullable: false),
                    QuotaId = table.Column<int>(nullable: true),
                    SectionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_PostOffice_PostOfficeId",
                        column: x => x.PostOfficeId,
                        principalTable: "PostOffice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Quota_QuotaId",
                        column: x => x.QuotaId,
                        principalTable: "Quota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceOfStudent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    InTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    OutTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceOfStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceOfStudent_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamMark",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObtainMark = table.Column<float>(nullable: false),
                    ResultStatus = table.Column<bool>(nullable: false),
                    Point = table.Column<double>(nullable: false),
                    Grade = table.Column<string>(maxLength: 2, nullable: true),
                    HighestMark = table.Column<float>(nullable: true),
                    Position = table.Column<int>(nullable: true),
                    ExamId = table.Column<int>(nullable: false),
                    ExamRoutineId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamMark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamMark_Exam_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamMark_ExamRoutine_ExamRoutineId",
                        column: x => x.ExamRoutineId,
                        principalTable: "ExamRoutine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamMark_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExamResult",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResultPublishDate = table.Column<DateTime>(type: "date", nullable: false),
                    TotalMark = table.Column<int>(nullable: false),
                    TotalObtainMark = table.Column<float>(nullable: false),
                    ResultStatus = table.Column<bool>(nullable: false),
                    Point = table.Column<double>(nullable: false),
                    Grade = table.Column<string>(maxLength: 2, nullable: false),
                    HighestMark = table.Column<float>(nullable: true),
                    Position = table.Column<int>(nullable: true),
                    TotalPresent = table.Column<int>(nullable: true),
                    Note = table.Column<string>(maxLength: 500, nullable: true),
                    ExamId = table.Column<int>(nullable: false),
                    SectionId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamResult_Exam_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamResult_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamResult_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    IsOptional = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationForm_BranchClassId",
                table: "ApplicationForm",
                column: "BranchClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationForm_PostOfficeId",
                table: "ApplicationForm",
                column: "PostOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationForm_QuotaId",
                table: "ApplicationForm",
                column: "QuotaId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceOfStaff_StaffId",
                table: "AttendanceOfStaff",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceOfStudent_StudentId",
                table: "AttendanceOfStudent",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceOfTeacher_TeacherId",
                table: "AttendanceOfTeacher",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_PostOfficeId",
                table: "Branch",
                column: "PostOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchClass_BranchId",
                table: "BranchClass",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchClass_SchoolClassId",
                table: "BranchClass",
                column: "SchoolClassId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchClass_SchoolVersionId",
                table: "BranchClass",
                column: "SchoolVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchClass_ShiftId",
                table: "BranchClass",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoutine_RoomId",
                table: "ClassRoutine",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoutine_SectionId",
                table: "ClassRoutine",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoutine_SubjectId",
                table: "ClassRoutine",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoutine_TeacherId",
                table: "ClassRoutine",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_District_DivisionId",
                table: "District",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Division_CountryId",
                table: "Division",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_BranchId",
                table: "Event",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_BranchId",
                table: "Exam",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamMark_ExamId",
                table: "ExamMark",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamMark_ExamRoutineId",
                table: "ExamMark",
                column: "ExamRoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamMark_StudentId",
                table: "ExamMark",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResult_ExamId",
                table: "ExamResult",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResult_SectionId",
                table: "ExamResult",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResult_StudentId",
                table: "ExamResult",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResultPoint_BranchId",
                table: "ExamResultPoint",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamRoutine_BranchClassId",
                table: "ExamRoutine",
                column: "BranchClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamRoutine_ExamId",
                table: "ExamRoutine",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamRoutine_SubjectId",
                table: "ExamRoutine",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_NoticeBoard_BranchId",
                table: "NoticeBoard",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliceStation_DistrictId",
                table: "PoliceStation",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_PostOffice_PoliceStationId",
                table: "PostOffice",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_BranchId",
                table: "Room",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_RulesRegulation_BranchId",
                table: "RulesRegulation",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_BranchClassId",
                table: "Section",
                column: "BranchClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_GroupId",
                table: "Section",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_RoomId",
                table: "Section",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_TeacherId",
                table: "Section",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_BranchId",
                table: "Staff",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_DesignationId",
                table: "Staff",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_PostOfficeId",
                table: "Staff",
                column: "PostOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_PostOfficeId",
                table: "Student",
                column: "PostOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_QuotaId",
                table: "Student",
                column: "QuotaId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_SectionId",
                table: "Student",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_StudentId",
                table: "StudentSubject",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_SubjectId",
                table: "StudentSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_GroupId",
                table: "Subject",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_SchoolClassId",
                table: "Subject",
                column: "SchoolClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_SchoolVersionId",
                table: "Subject",
                column: "SchoolVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_SubjectId",
                table: "SubjectTeacher",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_TeacherId",
                table: "SubjectTeacher",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskRoutine_StaffId",
                table: "TaskRoutine",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskRoutine_StaffTaskId",
                table: "TaskRoutine",
                column: "StaffTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_BranchId",
                table: "Teacher",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_DesignationId",
                table: "Teacher",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_PostOfficeId",
                table: "Teacher",
                column: "PostOfficeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationForm");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AttendanceOfStaff");

            migrationBuilder.DropTable(
                name: "AttendanceOfStudent");

            migrationBuilder.DropTable(
                name: "AttendanceOfTeacher");

            migrationBuilder.DropTable(
                name: "ClassRoutine");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "ExamMark");

            migrationBuilder.DropTable(
                name: "ExamResult");

            migrationBuilder.DropTable(
                name: "ExamResultPoint");

            migrationBuilder.DropTable(
                name: "Holiday");

            migrationBuilder.DropTable(
                name: "NoticeBoard");

            migrationBuilder.DropTable(
                name: "RoutineCondition");

            migrationBuilder.DropTable(
                name: "RulesRegulation");

            migrationBuilder.DropTable(
                name: "StudentSubject");

            migrationBuilder.DropTable(
                name: "SubjectTeacher");

            migrationBuilder.DropTable(
                name: "TaskRoutine");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ExamRoutine");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "StaffTask");

            migrationBuilder.DropTable(
                name: "Exam");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Quota");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "BranchClass");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "SchoolClass");

            migrationBuilder.DropTable(
                name: "SchoolVersion");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Designation");

            migrationBuilder.DropTable(
                name: "PostOffice");

            migrationBuilder.DropTable(
                name: "PoliceStation");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "Division");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
