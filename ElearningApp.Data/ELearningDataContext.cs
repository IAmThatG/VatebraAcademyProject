using System;
using ElearningApp.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ElearningApp.Data
{
    public class ELearningDataContext : IdentityDbContext<BaseUser, BaseRole, long>
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Enrolment> Enrolments { get; set; }

        public ELearningDataContext(DbContextOptions<ELearningDataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.SeedStudentData();
            builder.SeedCourseData();
            builder.SeedEnrolmentData();
        }
    }
}
