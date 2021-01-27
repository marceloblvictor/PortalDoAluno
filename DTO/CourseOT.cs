using PortalDoAluno.Models;
using System.Collections.Generic;

namespace PortalDoAluno.DTO
{
    public class CourseOT
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int TotalHours { get; set; }

        public string DepartmentName { get; set; }

        public IEnumerable<Student> Students { get; set; }
    }
}
