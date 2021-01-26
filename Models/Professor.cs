using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDoAluno.Models
{
    public class Professor : User
    {
        
        #region Navigation Properties
        public Department Department { get; set; }

        public int DepartmentID { get; set; }

        public List<Course> Courses { get; set; }

        #endregion

    }
}
