using Microsoft.EntityFrameworkCore;
using PortalDoAluno.Models;

namespace PortalDoAluno.Data
{
    
    sealed public class PortalDoAlunoDbContext : DbContext
    {
        public PortalDoAlunoDbContext(DbContextOptions<PortalDoAlunoDbContext> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Creates entities tables with names in singular, overriding the default behavior of using the DbSet name
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Student>().ToTable("Student");
        }
        
        public DbSet<Student> Students { get; set; }
        
        public DbSet<Course> Courses { get; set; }

    }
}
