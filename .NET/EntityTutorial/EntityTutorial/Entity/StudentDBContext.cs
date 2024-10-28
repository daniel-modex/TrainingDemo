using EntityTutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityTutorial.Entity
{
    public class StudentDBContext : DbContext
    {

        public StudentDBContext( DbContextOptions<StudentDBContext> options) : base(options) 
        { 
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
}
