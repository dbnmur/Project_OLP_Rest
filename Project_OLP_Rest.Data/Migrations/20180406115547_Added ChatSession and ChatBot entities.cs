using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Project_OLP_Rest.Data.Migrations
{
    public partial class AddedChatSessionandChatBotentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourse_Courses_CourseId",
                table: "TeacherCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourse_Users_TeacherId",
                table: "TeacherCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherCourse",
                table: "TeacherCourse");

            migrationBuilder.DropColumn(
                name: "OwnerUserID",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "TeacherCourse",
                newName: "TeacherCourses");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherCourse_TeacherId",
                table: "TeacherCourses",
                newName: "IX_TeacherCourses_TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherCourses",
                table: "TeacherCourses",
                columns: new[] { "CourseId", "TeacherId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourses_Courses_CourseId",
                table: "TeacherCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourses_Users_TeacherId",
                table: "TeacherCourses",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourses_Courses_CourseId",
                table: "TeacherCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourses_Users_TeacherId",
                table: "TeacherCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherCourses",
                table: "TeacherCourses");

            migrationBuilder.RenameTable(
                name: "TeacherCourses",
                newName: "TeacherCourse");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherCourses_TeacherId",
                table: "TeacherCourse",
                newName: "IX_TeacherCourse_TeacherId");

            migrationBuilder.AddColumn<int>(
                name: "OwnerUserID",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherCourse",
                table: "TeacherCourse",
                columns: new[] { "CourseId", "TeacherId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourse_Courses_CourseId",
                table: "TeacherCourse",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourse_Users_TeacherId",
                table: "TeacherCourse",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
