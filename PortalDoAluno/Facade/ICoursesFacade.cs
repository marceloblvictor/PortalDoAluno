using PortalDoAluno.DTO;
using PortalDoAluno.Models;
using System.Collections.Generic;

namespace PortalDoAluno.Facade
{
    public interface ICoursesFacade
    {
        /// <summary>
        /// Preenche o objeto de transferência representativo de um registro da entidade Course
        /// </summary>
        /// <param name="course">Um registro da entidade Course obtido do Banco de Dados</param>
        /// <returns>Um objeto de transferência representativo de um registro da entidade Course</returns>
        public CourseOT BuildOT(Course course);

        /// <summary>
        /// Popula uma lista de objetos de transferência representativos de registros da entidade Course
        /// </summary>
        /// <param name="courses">Lista de registros da entidade Course</param>
        /// <returns>Lista de objetos de transferência representativos de registros da entidade Course</returns>
        public IEnumerable<CourseOT> BuildOTList(IEnumerable<Course> courses);
    }
}