using Microsoft.EntityFrameworkCore.Migrations;

namespace A2.Migrations
{
    public partial class A22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentID = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    LastName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Program = table.Column<string>(unicode: false, maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    TeacherID = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    LastName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    TeacherResume = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    School = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Department = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.TeacherID);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    LoginName = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.LoginName);
                    table.ForeignKey(
                        name: "FK_Login_Student",
                        column: x => x.LoginName,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    RatingID = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    StudentID = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    Comment = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.RatingID);
                    table.ForeignKey(
                        name: "FK_Rating_Student",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appoinment",
                columns: table => new
                {
                    AppoinmentID = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    StudentID = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    TeacherID = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    AppoinmentDate = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    AppoinmentTime = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    AppoinmentCoz = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appoinment", x => x.AppoinmentID);
                    table.ForeignKey(
                        name: "FK_Appoinment_Student",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appoinment_Teacher",
                        column: x => x.TeacherID,
                        principalTable: "Teacher",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseCode = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    StudentID = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    TeacherID = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    CourseTitle = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseCode);
                    table.ForeignKey(
                        name: "FK_Course_Student",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Course_Teacher",
                        column: x => x.TeacherID,
                        principalTable: "Teacher",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appoinment_StudentID",
                table: "Appoinment",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Appoinment_TeacherID",
                table: "Appoinment",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_StudentID",
                table: "Course",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_TeacherID",
                table: "Course",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_StudentID",
                table: "Rating",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appoinment");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
