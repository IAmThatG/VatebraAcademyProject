using System;
using ElearningApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace ElearningApp.Data
{
    public class ELearningDataContext : DbContext
    {
        public ELearningDataContext(DbContextOptions<ELearningDataContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }
    }
}
