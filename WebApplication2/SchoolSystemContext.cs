using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2
{
    public class SchoolSystemDbContext : DbContext
    {
        public SchoolSystemDbContext() : base()
        {
        }
        public SchoolSystemDbContext(DbContextOptions<SchoolSystemDbContext> options)
               : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }
        public DbSet<Studentinformation> Studentinformations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add your own configuration here
            modelBuilder.Entity<TeacherCourse>().HasKey(c => new { c.TeacherId, c.CourseId });
            modelBuilder.Entity<StudentCourse>().HasKey(c => new { c.CourseId, c.StudentId });

        }

    }
}
