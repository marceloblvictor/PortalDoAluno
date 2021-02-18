using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDoAluno.Models
{
    public class Professor
    {

        [Key]
        public int ID { get; set; }
        
        #region Navigation Properties

        public Department Department { get; set; }

        public int DepartmentID { get; set; }

        public List<Course> Courses { get; set; }        

        public User User { get; set; }

        public int UserID { get; set; }        

        #endregion

    }
}
