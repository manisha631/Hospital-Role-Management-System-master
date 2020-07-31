using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital_Role_Management_System.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminLogin",
                columns: table => new
                {
                    UserPassword = table.Column<string>(unicode: false, maxLength: 45, nullable: false),
                    UserName = table.Column<string>(unicode: false, maxLength: 35, nullable: false),
                    UserType = table.Column<string>(unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.UserPassword);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    PatientId = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 45, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    Disease = table.Column<string>(unicode: false, maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    DoctorId = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 45, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Address = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Gender = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    PatientId = table.Column<string>(unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.DoctorId);
                    table.ForeignKey(
                        name: "FK_Doctor_Patient",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomId = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    RoomStatus = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    RoomFloorNo = table.Column<int>(nullable: false),
                    PatientId = table.Column<string>(unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Room_Patient",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_PatientId",
                table: "Doctor",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_PatientId",
                table: "Room",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminLogin");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
