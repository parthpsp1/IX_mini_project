using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniProjectBackendAPI.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlternatePhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BachlorsPercentage",
                table: "AspNetUsers",
                type: "decimal(5,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Certification",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiplomaPercentage",
                table: "AspNetUsers",
                type: "decimal(5,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DoctoratePhDPercentage",
                table: "AspNetUsers",
                type: "decimal(5,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MastersPercentage",
                table: "AspNetUsers",
                type: "decimal(5,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TenthPercentage",
                table: "AspNetUsers",
                type: "decimal(5,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TwelthPercentage",
                table: "AspNetUsers",
                type: "decimal(5,2)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WorkStatus",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlternatePhoneNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BachlorsPercentage",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Certification",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DiplomaPercentage",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DoctoratePhDPercentage",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MastersPercentage",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TenthPercentage",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TwelthPercentage",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WorkStatus",
                table: "AspNetUsers");
        }
    }
}
