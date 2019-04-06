using System;
using ElearningApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElearningApp.Data
{
    public class ELearningDataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Enrolment> Enrolments { get; set; }

        public ELearningDataContext(DbContextOptions<ELearningDataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //create composite key for joining table
            //modelBuilder.Entity<Enrolment>().HasKey();
        }
    }
}
