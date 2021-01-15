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
        [Display(Name="Nome do Aluno")]
        [Column("Name", TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string Name { get; set; }

        #region Navigation Properties

        public Course Course { get; set; }
        
        public int CourseID { get; set; }

        #endregion

        #endregion
    }

}
