using Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class BaseContext : IdentityDbContext<AppUser>
    {

        public BaseContext()
        {
            
        }

        public BaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EntityModel;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AppUser>().ToTable("Users");

            modelBuilder.Entity<StudentCourse>().HasKey(t => new {t.CourseId, t.StudentId});
            modelBuilder.Entity<TeacherCourse>().HasKey(t => new {t.CourseId, t.TeacherId});
            modelBuilder.Entity<Group>().HasAlternateKey(group => new
            {
                group.Year,
                group.Name
            });

            modelBuilder.Entity<Student>().HasAlternateKey(student => student.RegistrationNumber);
            modelBuilder.Entity<Student>().Property(p => p.FirstName).HasMaxLength(20);
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<TeacherCourse> TeacherCourses { get; set; }
    }
}