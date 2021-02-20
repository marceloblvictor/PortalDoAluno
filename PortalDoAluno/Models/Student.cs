using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalDoAluno.Models
{
    sealed public class Student 
    {
        #region Properties

        [Key]
        public int ID { get; set; }

        public string Name { get; set; }        

        public int CourseID { get; set; }

        #endregion
    }

}
