using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElearningApp.Data.Migrations
{
    public partial class CreatedFirstDatabaseSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseCode", "CourseDescription", "CourseTitle", "DateCreated", "DateUpdated" },
                values: new object[,]
                {
                    { 1L, "CSC 001", "This Course teaches Html", "Learning Html", new DateTime(2019, 4, 6, 16, 45, 58, 246, DateTimeKind.Local), new DateTime(2019, 4, 6, 16, 45, 58, 246, DateTimeKind.Local) },
                    { 2L, "CSC 002", "", "Learning Ef", new DateTime(2019, 4, 6, 16, 45, 58, 246, DateTimeKind.Local), new DateTime(2019, 4, 6, 16, 45, 58, 246, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Firstname", "Lastname", "MaticNumber" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 4, 6, 16, 45, 58, 241, DateTimeKind.Local), new DateTime(2019, 4, 6, 16, 45, 58, 244, DateTimeKind.Local), "Anthonia", "Ebhoaye", "12345678910" },
                    { 2L, new DateTime(2019, 4, 6, 16, 45, 58, 244, DateTimeKind.Local), new DateTime(2019, 4, 6, 16, 45, 58, 244, DateTimeKind.Local), "Lucky", "Moye", "12345678911" }
                });

            migrationBuilder.InsertData(
                table: "Enrolments",
                columns: new[] { "Id", "CourseId", "DateCreated", "DateUpdated", "StudentId" },
                values: new object[] { 1L, 1L, new DateTime(2019, 4, 6, 16, 45, 58, 247, DateTimeKind.Local), new DateTime(2019, 4, 6, 16, 45, 58, 247, DateTimeKind.Local), 1L });

            migrationBuilder.InsertData(
                table: "Enrolments",
                columns: new[] { "Id", "CourseId", "DateCreated", "DateUpdated", "StudentId" },
                values: new object[] { 2L, 1L, new DateTime(2019, 4, 6, 16, 45, 58, 247, DateTimeKind.Local), new DateTime(2019, 4, 6, 16, 45, 58, 247, DateTimeKind.Local), 2L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Enrolments",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Enrolments",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
