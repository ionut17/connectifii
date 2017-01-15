using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(BaseContext))]
    internal class BaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-preview1-22509")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Course", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Title")
                    .IsRequired()
                    .HasMaxLength(30);

                b.Property<int>("Year")
                    .HasMaxLength(1);

                b.HasKey("Id");

                b.ToTable("Courses");
            });

            modelBuilder.Entity("Core.Group", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(2);

                b.HasKey("Id");

                b.ToTable("Groups");
            });

            modelBuilder.Entity("Core.Student", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<DateTime>("BirthDate");

                b.Property<string>("FirstName")
                    .IsRequired()
                    .HasMaxLength(20);

                b.Property<Guid?>("GroupId");

                b.Property<string>("LastName")
                    .IsRequired()
                    .HasMaxLength(20);

                b.Property<string>("RegistrationNumber")
                    .IsRequired();

                b.Property<int>("Year")
                    .HasMaxLength(1);

                b.HasKey("Id");

                b.HasIndex("GroupId");

                b.ToTable("Students");
            });

            modelBuilder.Entity("Core.StudentCourse", b =>
            {
                b.Property<Guid?>("CourseId");

                b.Property<Guid?>("StudentId");

                b.Property<string>("StudentRegistrationNumber");

                b.HasKey("CourseId", "StudentId");

                b.HasIndex("StudentId");

                b.ToTable("StudentCourses");
            });

            modelBuilder.Entity("Core.Teacher", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<DateTime>("BirthDate");

                b.Property<string>("FirstName")
                    .IsRequired()
                    .HasMaxLength(20);

                b.Property<string>("LastName")
                    .IsRequired()
                    .HasMaxLength(20);

                b.HasKey("Id");

                b.ToTable("Teachers");
            });

            modelBuilder.Entity("Core.TeacherCourse", b =>
            {
                b.Property<Guid?>("CourseId");

                b.Property<Guid?>("TeacherId");

                b.HasKey("CourseId", "TeacherId");

                b.HasIndex("TeacherId");

                b.ToTable("TeacherCourses");
            });

            modelBuilder.Entity("Core.Student", b =>
            {
                b.HasOne("Core.Group", "Group")
                    .WithMany()
                    .HasForeignKey("GroupId");
            });

            modelBuilder.Entity("Core.StudentCourse", b =>
            {
                b.HasOne("Core.Course", "Course")
                    .WithMany("StudentCourses")
                    .HasForeignKey("CourseId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("Core.Student", "Student")
                    .WithMany("StudentCourses")
                    .HasForeignKey("StudentId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("Core.TeacherCourse", b =>
            {
                b.HasOne("Core.Course", "Course")
                    .WithMany("TeacherCourses")
                    .HasForeignKey("CourseId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("Core.Teacher", "Teacher")
                    .WithMany("StudentCourses")
                    .HasForeignKey("TeacherId")
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}