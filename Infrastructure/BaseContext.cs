using Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class BaseContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}