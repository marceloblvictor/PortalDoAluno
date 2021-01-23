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

            // Configures the relationship delete to Restrict. By convention, the Entity Framework enables cascade 
            // delete for non-nullable foreign keys and for many-to-many relationships
            //modelBuilder.Entity<Department>()
            //    .HasOne(d => d.Administrator)
            //    .WithMany()
            //    .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Student> Students { get; set; }
        
        public DbSet<Course> Courses { get; set; }

    }
}
