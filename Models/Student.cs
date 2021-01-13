using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalDoAluno.Models
{
    sealed public class Student : User
    {
        #region Properties

        [Key]
        public int ID { get; set; }

        [Required]
        [Column("Name", TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Column("GlobalRating", TypeName = "decimal(5, 2)")]
        public decimal GlobalRating { get; set; }
        
        
        #region Navigation Properties

        public Course Courses { get; set; }

        #endregion

        #endregion
    }

}
