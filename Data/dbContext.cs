using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Data
{
    public class dbContext:DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) :base(options)
        {
                
        }
        public DbSet<Student> Student { get; set; }
        public DbSet<Standard> Standard { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StandardTeacher> StandardTeachers{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StandardTeacher>().HasKey(x => new { x.TeacherId, x.StandardId });
            modelBuilder.Entity<StandardTeacher>()
                .HasOne(x => x.Teacher)
                .WithMany(x => x.StandardTeachers)
                .HasForeignKey(x => x.TeacherId);
            modelBuilder.Entity<StandardTeacher>()
                .HasOne(x => x.Standard)
                .WithMany(pc => pc.StandardTeachers)
                .HasForeignKey(x => x.StandardId);
        }
    }
}
