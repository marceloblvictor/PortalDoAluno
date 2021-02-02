using PortalDoAluno.Models;
using System.Collections.Generic;

namespace PortalDoAluno.DTO
{
    public class CourseOT
    {
        /// <summary>
        /// ID do Course
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Nome do Course
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descrição do Course
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Carga Horária do Course
        /// </summary>
        public int TotalHours { get; set; }

        /// <summary>
        /// Nome do Department a que pertence o Course
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Lista de Students que estão inscritos no Course
        /// </summary>
        public IEnumerable<Student> Students { get; set; }
    }
}
