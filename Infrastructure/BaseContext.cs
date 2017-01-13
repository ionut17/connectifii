using Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class BaseContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<TeacherCourse> TeacherCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EntityModel;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StudentCourse>().HasKey(t => new { t.CourseId, t.StudentId });
            modelBuilder.Entity<TeacherCourse>().HasKey(t => new { t.CourseId, t.TeacherId });
        }
    }
}
