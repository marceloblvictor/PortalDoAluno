using PortalDoAluno.Data;
using PortalDoAluno.DTO;
using PortalDoAluno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PortalDoAluno.Repository
{
    public interface ICoursesRepository
    {
        /// <summary>
        /// Instância do contexto do Banco de Dados PortalDoAluno
        /// </summary>
        public PortalDoAlunoDbContext _context { get; set; }
        
        /// <summary>
        /// Obtém um registro da entidade Course
        /// </summary>
        /// <param name="id">ID do registro da entidade Course buscado</param>
        /// <returns>Retorna o registro da entidade Course conforme o ID passado por parâmetro</returns>
        public Task<Course> GetOne(int id, bool getStudents);

        /// <summary>
        /// Obtém todos os registros da entidade Course
        /// </summary>
        /// <returns>Retorna um IEnumerable com todos os registros da entidade Course</returns>
        public Task<IEnumerable<Course>> GetAll();

        /// <summary>
        /// Cria um registro da entidade Course
        /// </summary>
        /// <param name="course">Uma instância da entidade Course</param>
        /// <returns>Retorna um boolean indicando se a operação foi bem sucedida </returns>
        public Task<bool> Add(Course course);

        /// <summary>
        /// Edita o registro da entidade Course cujo ID é passado como parâmetro
        /// </summary>
        /// <param name="course">A instância da entidade Course que substiturá o registro da entidade Course</param>
        /// <param name="courseID">ID do registro da entidade Course que será editado</param>
        /// <returns>Retorna um boolean indicando se a operação foi bem sucedida </returns>
        public Task<bool> Update(Course course);

        /// <summary>
        /// Exclui o registro da entidade Course cujo ID é passado como parâmetro
        /// </summary>
        /// <param name="courseID">ID do registro da entidade Course a ser excluído</param>
        public Task<bool> Delete(int courseID);

        /// <summary>
        /// Conta a quantidade de registros da entidade Course
        /// </summary>
        /// <returns>Retorna a quantidade de registros da entidade Course</returns>
        public Task<int> Count();




    }
}
