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
        /// Manipula as instâncias do modelo Student
        /// </summary>
        public DbSet<Student> Students { get; set; }
        
    }
}
