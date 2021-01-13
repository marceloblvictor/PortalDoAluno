using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalDoAluno.Models
{

    sealed public class Course
    {
        #region Properties

        [Key]
        public int ID { get; set; }
        
        [Column("Name", TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int TotalHours { get; set; }
        
        public ContentType ContentType { get; set; }

        #region Navigation Properties

        public List<Student> Students { get; set; }

        #endregion


        #endregion
    }
}
