using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentMgmt.Migrations
{
    public partial class Student_Mnangement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    course_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_Name = table.Column<string>(nullable: true),
                    start_date = table.Column<DateTime>(nullable: false),
                    End_date = table.Column<DateTime>(nullable: false),
                    Course_duration = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.course_ID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    student_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_Name = table.Column<string>(nullable: true),
                    student_Email = table.Column<string>(nullable: true),
                    student_Mobile = table.Column<string>(nullable: true),
                    student_Address = table.Column<string>(nullable: true),
                    course_ID = table.Column<int>(nullable: false),
                    Course_objcourse_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.student_ID);
                    table.ForeignKey(
                        name: "FK_Student_Course_Course_objcourse_ID",
                        column: x => x.Course_objcourse_ID,
                        principalTable: "Course",
                        principalColumn: "course_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_Course_objcourse_ID",
                table: "Student",
                column: "Course_objcourse_ID");

            var sqlFile = Path.Combine(".\\DatabaseScript", @"data.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}
