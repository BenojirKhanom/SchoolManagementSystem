using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class bkashmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Student",
                nullable: true,
                computedColumnSql: "[FirstName] + ' ' + [LastName]PERSISTED",
                oldClrType: typeof(string),
                oldType: "nvarchar(101)",
                oldMaxLength: 101);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "ApplicationForm",
                nullable: true,
                computedColumnSql: "[FirstName] + ' ' + [LastName]PERSISTED",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantId",
                table: "ApplicationForm",
                nullable: true,
                computedColumnSql: "N'1'+ RIGHT('0000000'+CAST(Id AS VARCHAR(7)),7)PERSISTED",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "BkashModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paymentID = table.Column<string>(nullable: true),
                    createTime = table.Column<string>(nullable: true),
                    updateTime = table.Column<string>(nullable: true),
                    trxID = table.Column<string>(nullable: true),
                    transactionStatus = table.Column<string>(nullable: true),
                    amount = table.Column<decimal>(nullable: false),
                    currency = table.Column<string>(nullable: true),
                    merchantInvoiceNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BkashModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BkashModel");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Student",
                type: "nvarchar(101)",
                maxLength: 101,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true,
                oldComputedColumnSql: "[FirstName] + ' ' + [LastName]PERSISTED");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "ApplicationForm",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true,
                oldComputedColumnSql: "[FirstName] + ' ' + [LastName]PERSISTED");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantId",
                table: "ApplicationForm",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true,
                oldComputedColumnSql: "N'1'+ RIGHT('0000000'+CAST(Id AS VARCHAR(7)),7)PERSISTED");
        }
    }
}
