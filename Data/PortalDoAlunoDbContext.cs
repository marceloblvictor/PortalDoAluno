using Microsoft.EntityFrameworkCore;
using PortalDoAluno.Model;

namespace PortalDoAluno.Data
{
    /// <summary>
    /// Contexto da sessão do Entity Framework com o Banco de Dados da aplicação Portal do Aluno
    /// </summary>
    public class PortalDoAlunoDbContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        
    }
}
