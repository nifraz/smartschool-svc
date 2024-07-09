using Microsoft.EntityFrameworkCore;
using SmartSchool.Schema.Configurations;
using SmartSchool.Schema.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema
{
    public class SmartSchoolDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public SmartSchoolDbContext(DbContextOptions<SmartSchoolDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
        }
    }
}
