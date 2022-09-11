using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniProjectBackendAPI.Migrations
{
    public partial class jobs_applied : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlternatePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenthPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    TwelthPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    DiplomaPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    BachlorsPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    MastersPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    DoctoratePhDPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    WorkStatus = table.Column<bool>(type: "bit", nullable: false),
                    Certification = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "JobsApplied",
                columns: table => new
                {
                    JobsAppliedID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobsApplied", x => x.JobsAppliedID);
                    table.ForeignKey(
                        name: "FK_JobsApplied_Jobs_JobID",
                        column: x => x.JobID,
                        principalTable: "Jobs",
                        principalColumn: "JobID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobsApplied_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobsApplied_JobID",
                table: "JobsApplied",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "IX_JobsApplied_UserID",
                table: "JobsApplied",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobsApplied");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
