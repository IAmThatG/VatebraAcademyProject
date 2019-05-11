using System;
using ElearningApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElearningApp.Data
{
    public static class ELearningDataContextSeeder
    {
        public static void SeedStudentData(this ModelBuilder builder)
        {
            builder.Entity<Student>().HasData(
                new Student[]
                {
                    new Student{ Id = 1, Firstname = "Anthonia", Lastname = "Ebhoaye", MaticNumber = "12345678910", DateCreated = DateTime.Now, DateUpdated = DateTime.Now},
                    new Student{ Id = 2, Firstname = "Lucky", Lastname = "Moye", MaticNumber = "12345678911", DateCreated = DateTime.Now, DateUpdated = DateTime.Now }
                }
            );
        }

        public static void SeedCourseData(this ModelBuilder builder)
        {
            builder.Entity<Course>().HasData(
                new Course[]
                {
                    new Course{ Id = 1, CourseTitle = "Learning Html", CourseCode = "CSC 001", CourseDescription = "This Course teaches Html", DateCreated = DateTime.Now, DateUpdated = DateTime.Now },
                    new Course{ Id = 2, CourseTitle = "Learning Ef", CourseCode = "CSC 002", CourseDescription = "", DateCreated = DateTime.Now, DateUpdated = DateTime.Now}
                }
            );
        }

        public static void SeedEnrolmentData(this ModelBuilder builder)
        {
            builder.Entity<Enrolment>().HasData(
                new Enrolment[]
                {
                    new Enrolment{ Id = 1, CourseId = 1, StudentId = 1, DateCreated = DateTime.Now, DateUpdated = DateTime.Now },
                    new Enrolment{ Id = 2, CourseId = 1, StudentId = 2, DateCreated = DateTime.Now, DateUpdated = DateTime.Now }
                }
            );
        }
    }
}
