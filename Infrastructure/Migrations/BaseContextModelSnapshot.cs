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

            modelBuilder.Entity("Core.Student", b =>
            {
                b.Property<string>("RegistrationNumber")
                    .ValueGeneratedOnAdd()
                    .HasMaxLength(100);

                b.Property<DateTime>("BirthDate");

                b.Property<string>("FirstName")
                    .IsRequired()
                    .HasMaxLength(20);

                b.Property<string>("Group")
                    .IsRequired()
                    .HasMaxLength(2);

                b.Property<string>("LastName")
                    .IsRequired()
                    .HasMaxLength(20);

                b.Property<int>("Year")
                    .HasMaxLength(1);

                b.HasKey("RegistrationNumber");

                b.ToTable("Students");
            });
        }
    }
}