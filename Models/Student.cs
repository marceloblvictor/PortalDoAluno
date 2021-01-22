using System;
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
        [StringLength(100, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z][a-zA-Z]*\s([A-Z][a-zA-Z]\s*)*$", ErrorMessage = "Nome e sobrenomes com primeira letra maiúscula")]
        public string Name { get; set; }

        #region Navigation Properties

        public Course Course { get; set; }
        
        public int CourseID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Matrícula")]        
        public DateTime Registration { get; set; }

        #endregion

        #endregion
    }

}
