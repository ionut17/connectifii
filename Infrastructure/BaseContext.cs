﻿using Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class BaseContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EntityModel;Trusted_Connection=True;");
        }
    }
}