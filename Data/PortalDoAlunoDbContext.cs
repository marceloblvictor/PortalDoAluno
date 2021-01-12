using Microsoft.EntityFrameworkCore;
using PortalDoAluno.Models;

namespace PortalDoAluno.Data
{
    /// <summary>
    /// Contexto da sessão do Entity Framework com o Banco de Dados da aplicação Portal do Aluno
    /// </summary>
    sealed public class PortalDoAlunoDbContext : DbContext
    {
        /// <summary>
        /// Construtor do contexto do Entity Framework da aplicação
        /// Passa as opções de configurações para o Construtor de DbContext
        /// </summary>
        /// <param name="options">Opções de configurações do DbContext</param>
        public PortalDoAlunoDbContext(DbContextOptions<PortalDoAlunoDbContext> options) : base(options) { }

        /// <summary>
        /// Configura os modelos de entidades usando a Fluent API
        /// </summary>
        /// <param name="modelBuilder">Interface que permite a configuração dos modelos de entidades e seus relacionamentos </param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Blog>()
            //    .HasOne(b => b.BlogImage)
            //    .WithOne(i => i.Blog)
            //    .HasForeignKey<BlogImage>(b => b.BlogForeignKey);
        }

        /// <summary>
        /// Manipula as instâncias da entidade Student
        /// </summary>
        public DbSet<Student> Student { get; set; }

        /// <summary>
        /// Manipula as instâncias da entidade Student
        /// </summary>
        public DbSet<PortalDoAluno.Models.Test> Test { get; set; }

    }
}
