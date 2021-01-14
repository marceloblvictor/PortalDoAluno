using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalDoAluno.Models
{

    sealed public class Course : IValidatableObject
    {
        #region Properties

        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nome do Curso", Description = "Máximo de 100 caracteres")]
        [Column("FirstName", TypeName = "varchar(100)")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(0, 500)]
        public int TotalHours { get; set; }
        
        public ContentType ContentType { get; set; }

        #region Navigation Properties

        public List<Student> Students { get; set; }


        #endregion


        #endregion

        #region Implemented Methods

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
