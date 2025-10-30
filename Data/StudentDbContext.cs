using DotNet_Web_API.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet_Web_API.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}


