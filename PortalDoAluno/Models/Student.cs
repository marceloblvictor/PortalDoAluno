using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalDoAluno.Models
{
    sealed public class Student : User
    {
        #region Properties

        public List<Enrollment> Enrollments;

        #endregion
    }

}
