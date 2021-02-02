using PortalDoAluno.DTO;
using PortalDoAluno.Models;
using System.Collections.Generic;

namespace PortalDoAluno.Facade
{
    public class CoursesFacade : ICoursesFacade
    {
        /// <summary>
        /// Preenche o objeto de transferência representativo de um registro da entidade Course
        /// </summary>
        /// <param name="course">Um registro da entidade Course obtido do Banco de Dados</param>
        /// <returns>Um objeto de transferência representativo de um registro da entidade Course</returns>
        public CourseOT BuildOT(Course course)
        {
            var courseOT = new CourseOT();

            courseOT.ID = course.ID;
            courseOT.Name = course.Name;
            courseOT.Description = course.Description;
            courseOT.TotalHours = course.TotalHours;
            courseOT.Students = course.Students;

            return courseOT;
        }
        /// <summary>
        /// Popula uma lista de objetos de transferência representativos de registros da entidade Course
        /// </summary>
        /// <param name="courses">Lista de registros da entidade Course</param>
        /// <returns>Lista de objetos de transferência representativos de registros da entidade Course</returns>
        public IEnumerable<CourseOT> BuildOTList(IEnumerable<Course> courses)
        {
            var coursesOT = new List<CourseOT>();

            foreach (var course in courses)
            {
                var courseOT = this.BuildOT(course);
                coursesOT.Add(courseOT);
            }

            return coursesOT;
        }
    }
}
